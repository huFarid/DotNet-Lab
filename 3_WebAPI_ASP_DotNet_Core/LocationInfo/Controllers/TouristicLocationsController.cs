using LocationInfo.Models;
using Microsoft.AspNetCore.Mvc;

namespace LocationInfo.Controllers
{
    [Route("/api/Cities/{cityId}/touristiclocation")]
    [ApiController]
    public class TouristicLocationsController : ControllerBase
    {

        [HttpGet]
        public ActionResult<IEnumerable<TouristicLocationsDto>> GetTouristicLocations(int cityId)
        {
            var city = CitiesDataStore.citiesDataStore.Cities.FirstOrDefault(i => i.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }
            return (Ok(city.TouristicLocations));
        }

        [HttpGet("{TouristicLocationID}", Name ="GetTouristicLocation")]
        public ActionResult<TouristicLocationsDto> GetTouristicLocation(int cityId, int TouristicLocationID)
        {
            var city = CitiesDataStore.citiesDataStore.Cities.FirstOrDefault(i => i.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }

            var location = city.TouristicLocations.FirstOrDefault(i => i.Id == TouristicLocationID);

            if (location == null)
            {
                return NotFound();
            }
            return Ok(location);

        }

        #region POST

        [HttpPost]
        public ActionResult<TouristicLocationsDto> CreateTouristicLocation(
            int cityID, TouristicLocationsForCreationDto touristicLocation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var city = CitiesDataStore.citiesDataStore.Cities.FirstOrDefault(i => i.Id == cityID);
            if (city == null)
            {
                return NotFound();
            }

            var maxIdOfTouristicLocations = CitiesDataStore.citiesDataStore.Cities.SelectMany(c => c.TouristicLocations)
                .Max(i => i.Id);



            var createdTouristicLocationDTO = new TouristicLocationsDto
            {
                Id = maxIdOfTouristicLocations + 1,
                Name = touristicLocation.Name,
                Description = touristicLocation.Description
            };

            city.TouristicLocations.Add(createdTouristicLocationDTO);


            return CreatedAtAction("GetTouristicLocation",
                           new
                           {
                               cityId = cityID,
                               TouristicLocationID = createdTouristicLocationDTO.Id
                           },
                           createdTouristicLocationDTO
                           );




        }
        #endregion

        #region UPDATE
        [HttpPut("{touristicLocationId}")]
        public ActionResult TrouristicLocationsDto(
            int cityID, int touristicLocationId, TouristicLocationsForUpdateDto touristicLocationsForUpdate)
        {
            var city = CitiesDataStore.citiesDataStore.Cities.FirstOrDefault(i => i.Id == cityID);
            if(city == null) 
            { return NotFound(); }

            var touristicLocation = city.TouristicLocations.SingleOrDefault(c => c.Id == touristicLocationId);


            touristicLocation.Name = touristicLocationsForUpdate.Name;
            touristicLocation.Description = touristicLocationsForUpdate.Description;

            return NoContent();
        }

        #endregion



    }
}
