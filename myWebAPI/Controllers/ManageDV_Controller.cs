using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IDS_WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ManageDV_Controller : ControllerBase
    {
        private static readonly string[] Drivers = new[]
{
            "Adam", "Oliver", "Noah", "Jake", "Ava", "Mazda", "Elijah", "Benjamin", "Charlotte", "Henry", "Lucas"
        };

        private static readonly string[] Brand = new[]
        {
            "Audi", "BMW", "Toyota", "Ford", "Mercedes-benz", "Mazda", "Kia", "Honda", "Peugeot", "Hyundai", "Nissan"
        };

        private readonly ILogger<ManageDV_Controller> _logger;

        public ManageDV_Controller(ILogger<ManageDV_Controller> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<ManageDV> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new ManageDV
            {
                Driver = Drivers[rng.Next(Brand.Length)],
                Trips = rng.Next(0, 75),
                Vechile = Brand[rng.Next(Brand.Length)]
            })
            .ToArray();
        }
    }
}
