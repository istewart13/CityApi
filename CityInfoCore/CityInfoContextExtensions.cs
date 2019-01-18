using CityInfoCore.Data;
using CityInfoCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfoCore
{
    public static class CityInfoContextExtensions
    {
        public static void EnsureSeedDataForContext(this CityInfoContext _context)
        {
            if (_context.Cities.Any())
            {
                return;
            }

            // initialise seed data
            var cities = new List<City>()
            {
                new City()
                {
                    Name = "New York City",
                    Description = "The one with the big park.",
                    PointsOfInterest = new List<PointOfInterest>()
                    {
                        new PointOfInterest()
                        {
                            Name = "Central Park",
                            Description = "Most visited urban park in US.",
                        },
                        new PointOfInterest()
                        {
                            Name = "Empire State Building",
                            Description = "102-story skyscraper in Midtown Manhatten.",
                        }
                    }
                },
                new City()
                {
                    Name = "Antwerp",
                    Description = "The one with the cathedral that was never really finished.",
                    PointsOfInterest = new List<PointOfInterest>()
                    {
                        new PointOfInterest()
                        {
                            Name = "Cathedral of Our Lady",
                            Description = "Gothic style cathedral.",
                        },
                        new PointOfInterest()
                        {
                            Name = "Antwerp Central Station",
                            Description = "Finest example of railway architecture in Belgium.",
                        }
                    }
                },
                new City()
                {
                    Name = "Paris",
                    Description = "The one with that big tower.",
                    PointsOfInterest = new List<PointOfInterest>()
                    {
                        new PointOfInterest()
                        {
                            Name = "Eiffel Tower",
                            Description = "Wrought iron, lattice tower on the Champ de Mars.",
                        },
                        new PointOfInterest()
                        {
                            Name = "The Louvre",
                            Description = "World's largest museum.",

                        }
                    }
                }
            };

            _context.Cities.AddRange(cities);
            _context.SaveChanges();

        }
    }
}
