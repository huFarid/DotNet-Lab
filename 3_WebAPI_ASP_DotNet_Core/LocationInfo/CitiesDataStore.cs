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
                new CityDTO() { Id = 1, Name = "Tehran", Description = "Capital" ,
                TouristicLocations = new List <TouristicLocationsDto> 
                {
                    new TouristicLocationsDto() 
                    {
                        Id = 1,
                        Name = "Eiffel Tower",
                        Description ="Largest in Europe"
                    }
                    ,
                     new TouristicLocationsDto()
                    {
                        Id = 2,
                        Name = "River",
                        Description ="Water in River"
                    }
                     , new TouristicLocationsDto()
                    {
                        Id = 3,
                        Name = "Eiffel Tower 2",
                        Description ="Second best in Europe"
                    }

                }
                },
                new CityDTO() { Id = 2, Name = "Hamedan", Description = "Historica",
                 TouristicLocations = new List <TouristicLocationsDto>
                {
                     new TouristicLocationsDto()
                    {
                        Id = 4,
                        Name = "Hamedan Eiffel Tower",
                        Description ="Largest in Hamedan"
                    }
                    ,
                     new TouristicLocationsDto()
                    {
                        Id = 5,
                        Name = "Hamedan River",
                        Description ="Hamedan River "
                    }
                     , new TouristicLocationsDto()
                    {
                        Id = 6,
                        Name = "Hamedan Eiffel Tower 2",
                        Description ="Second best in Hamedan"
                    }

                 }




                },
                new CityDTO() { Id = 3, Name = "Esfahan", Description = "Industrial" ,
                                 TouristicLocations = new List <TouristicLocationsDto>
                {
                     new TouristicLocationsDto()
                    {
                        Id = 7,
                        Name = "Hamedan Eiffel Tower3",
                        Description ="Largest in Hamedan3"
                    }
                    ,
                     new TouristicLocationsDto()
                    {
                        Id = 8,
                        Name = "Hamedan River3",
                        Description ="Hamedan River3 "
                    }
                     , new TouristicLocationsDto()
                    {
                        Id = 9,
                        Name = "Hamedan Eiffel Tower 3",
                        Description ="Second best in Hamedan3"
                    }

                 }
                }
            };
        }
    }
}
