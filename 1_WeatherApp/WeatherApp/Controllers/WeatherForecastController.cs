using Microsoft.AspNetCore.Mvc;
using WeatherApp.Data;

namespace WeatherApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly WeatherDbContext _weatherDbContext;
        
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, WeatherDbContext weatherDbContext)
        {
            _logger = logger;
            this._weatherDbContext = weatherDbContext;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return _weatherDbContext.WeatherForecasts.ToList();

        }

        [HttpGet]
        [Route("{id}")]
        public WeatherForecast? GetById(int id)
        {
            return _weatherDbContext.WeatherForecasts.FirstOrDefault(x => x.Id == id);

        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult? DeleteById(int id)
        {
            var weatherinfo = _weatherDbContext.WeatherForecasts.FirstOrDefault(x => x.Id == id);
            if (weatherinfo != null) 
            {
                _weatherDbContext.WeatherForecasts.Remove(weatherinfo);
                return Ok();
            }
            else
            {
                return BadRequest("Weather info was not found!");
                    
            }

        }


        [HttpPost]
        public IActionResult AddNew(WeatherForecastDataTransferObject model)
        {

            try
            {
                // validation
                var _weatherData = new WeatherForecast
                {
                    Date = DateOnly.Parse(model.Date),
                    Summary = model.Summary,
                    TemperatureC = model.TemperatureC,

                };

                _weatherDbContext.WeatherForecasts.Add(_weatherData);
                _weatherDbContext.SaveChanges();
                return Ok();

            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }


        
            
        }


        [HttpPut]
        public IActionResult Edit(WeatherForecastEditDTO model)
        {

            var weatherInfo = _weatherDbContext.WeatherForecasts.FirstOrDefault(x => x.Id == model.Id);

            if (weatherInfo == null)
            {
                return BadRequest("Weather data is not found!");

            }
            else
            {
                weatherInfo.Summary = model.Summary;
                weatherInfo.TemperatureC = model.TemperatureC;
                weatherInfo.Date =DateOnly.Parse(model.Date);
                _weatherDbContext.SaveChanges();
                return Ok();
            }

        }


    }
}
