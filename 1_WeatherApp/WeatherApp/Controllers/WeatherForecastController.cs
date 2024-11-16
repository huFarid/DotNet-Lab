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
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            //    TemperatureC = Random.Shared.Next(-20, 55),
            //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            //})
            //.ToArray();
        }

        [HttpGet]
        [Route("{id}")]
        public WeatherForecast? GetById(int id)
        {
            return _weatherDbContext.WeatherForecasts.FirstOrDefault(x => x.Id == id);

        }



        [HttpPost]
        public IActionResult AddNew(WeatherForecastDataTransferObject model)
        {

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


    }
}
