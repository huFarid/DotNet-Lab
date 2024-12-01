using LocationInfo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace LocationInfo.Controllers
{

    [ApiController]
    [Route("/api/Cities")] 
    
    public class CitiesController:ControllerBase
    {

        [HttpGet]
        public ActionResult<IEnumerable<CityDTO>> GetCities()
        {


            return Ok(CitiesDataStore.citiesDataStore.Cities);
        }




        [HttpGet("/{Id}")]
        public ActionResult GetCity(int Id)
        {
            var city = CitiesDataStore.citiesDataStore.Cities.FirstOrDefault(x => x.Id == Id);

            if (city != null) 
            {
                return Ok(city);
            }
            return NotFound();

            
        }




    }
}
