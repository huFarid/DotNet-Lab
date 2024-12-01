using LocationInfo.Models;

namespace LocationInfo
{
    public class CitiesDataStore
    {
        public List<CityDTO> Cities { get; set; }
        public static CitiesDataStore citiesDataStore { get; } = new CitiesDataStore();
        public CitiesDataStore()
        {
            Cities = new List<CityDTO>()
            {
                new CityDTO() { Id = 1, Name = "Tehran", Description = "Capital" },
                new CityDTO() { Id = 2, Name = "Hamedan", Description = "Historica" },
                new CityDTO() { Id = 3, Name = "Esfahan", Description = "Industrial" }
            };
        }
    }
}
