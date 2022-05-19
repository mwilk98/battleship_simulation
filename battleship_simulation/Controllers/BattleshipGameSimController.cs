using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using battleship_simulation.Interfaces;
using battleship_simulation.Services;

namespace battleship_simulation.Controllers
{
    /* controller providing communication with frontend of simulation */
    [ApiController]
    [Route("[controller]")]
    public class BattleshipGameSimController : ControllerBase
    {
        static readonly IGameRepository repository = new GameRepository();

        private readonly ILogger<BattleshipGameSimController> _logger;

        public BattleshipGameSimController(ILogger<BattleshipGameSimController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult(new BattleshipGameSim { PlayerOneBoard = repository.GetFirst(), PlayerTwoBoard = repository.GetSecond(), events = repository.GetEvents() });
        }

        [HttpPost]
        public void Add()
        {
            repository.Add();
        }
    }
}
