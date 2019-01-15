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
        [HttpGet()]
        public IActionResult GetCities()
        {
            return new JsonResult(CitiesDataStore.Current.Cities);
        }
    }
}
