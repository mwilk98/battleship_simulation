using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace battleship_simulation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        static readonly battleship_simulation.IGameRepository repository = new battleship_simulation.GameRepository();

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult(new WeatherForecast { Board = repository.GetFirst(), Board2 = repository.GetSecond() });
        }

        [HttpPost]
        public void Add()
        {
            repository.Add();
        }
    }
}
