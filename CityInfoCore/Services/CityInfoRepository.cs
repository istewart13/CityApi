﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfoCore.Data;
using CityInfoCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfoCore.Services
{
    public class CityInfoRepository : ICityInfoRepository
    {
        private CityInfoContext _context;

        public CityInfoRepository(CityInfoContext context)
        {
            _context = context;
        }

        public IEnumerable<City> GetCities()
        {
            return _context.Cities.OrderBy(c => c.Name).ToList();
        }

        public City GetCity(int cityId, bool includePointsOfInterest)
        {
            if (includePointsOfInterest)
            {
                return _context.Cities.Include(c => c.PointsOfInterest).FirstOrDefault(c => c.Id == cityId);
            }

            return _context.Cities.FirstOrDefault(c => c.Id == cityId);
        }

        public PointOfInterest GetPointOfInterestForCity(int cityId, int pointOfInterestId)
        {
            return _context.PointsOfInterest.FirstOrDefault(p => p.city.Id == cityId && p.Id == pointOfInterestId);
        }

        public IEnumerable<PointOfInterest> GetPointsOfInterestForCity(int cityId)
        {
            return _context.PointsOfInterest.Where(c => c.Id == cityId).OrderBy(p => p.Name).ToList();
        }
    }
}
