using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherApp
{
    public class WeatherForecast
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        [NotMapped]
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
    public class WeatherForecastDataTransferObject
    {

        public String? Date { get; set; }

        public int TemperatureC { get; set; }

        public string? Summary { get; set; }
    }
}
