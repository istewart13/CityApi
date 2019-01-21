using AutoMapper;
using CityInfoCore.Entities;
using CityInfoCore.Models;
using CityInfoCore.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfoCore.Controllers
{
    [Route("api/[controller]")]
    public class CitiesController : Controller
    {
        private ICityInfoRepository _cityInfoRepository;
        private readonly IMapper _mapper;

        public CitiesController(ICityInfoRepository cityInfoRepository, IMapper mapper)
        {
            _cityInfoRepository = cityInfoRepository;
            _mapper = mapper;
        }

        [HttpGet()]
        public IActionResult GetCities()
        {
            var cityEntities = _cityInfoRepository.GetCities();

            var results = _mapper.Map<IEnumerable<CityWithoutPointsOfInterestDto>> (cityEntities);
                
            return Ok(results);
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id, bool includePointsOfInterest = false)
        {
            var city = _cityInfoRepository.GetCity(id, includePointsOfInterest);

            if (city == null)
            {
                return NotFound();
            }

            if (includePointsOfInterest)
            {
                var cityResult = new CityDto()
                {
                    Id = city.Id,
                    Description = city.Description,
                    Name = city.Name,
                };


                foreach (var pointOfInterest in city.PointsOfInterest)
                {
                    cityResult.PointsOfInterest.Add(
                        new PointOfInterestDto()
                        {
                            Id = pointOfInterest.Id,
                            Description = pointOfInterest.Description,
                            Name = pointOfInterest.Name,
                        });
                }
                return Ok(cityResult);
            }

            else
            {
                var cityResult = new CityWithoutPointsOfInterestDto()
                {
                    Id = city.Id,
                    Description = city.Description,
                    Name = city.Name,
                };
                return Ok(cityResult);
            }
        }
    }
}
