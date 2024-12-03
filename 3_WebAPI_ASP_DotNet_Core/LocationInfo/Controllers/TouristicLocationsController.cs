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

        [HttpGet("{TouristicLocationID}")]
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

        [HttpPost]
        public ActionResult<TouristicLocationsDto> CreateTouristicLocations (
              int cityId, TouristicLocationsForCreationDto touristicLocations)
        {
            var city = CitiesDataStore.citiesDataStore.Cities.FirstOrDefault (i => i.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }

            var maxIdOfTouristicLocations = CitiesDataStore.citiesDataStore.Cities.SelectMany(c => c.TouristicLocations)
                .Max(p => p.Id);



            var  createdTouristicLocation = new TouristicLocationsDto()
            { Id = maxIdOfTouristicLocations + 1,
              Name = touristicLocations.Name,
              Description = touristicLocations.Description,
            };

            city.TouristicLocations.Add(createdTouristicLocation);

            return CreatedAtAction("GetPointOfInterest",
                new
                {
                    cityId = cityId,
                    Touristiclocationsid = createdTouristicLocation.Id
                },
                createdTouristicLocation
                );



        }

    }
}
