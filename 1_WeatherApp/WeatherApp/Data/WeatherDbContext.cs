using Microsoft.EntityFrameworkCore;

namespace WeatherApp.Data
{
    public class WeatherDbContext : DbContext
    {


        public WeatherDbContext(DbContextOptions<WeatherDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    }


   
}
