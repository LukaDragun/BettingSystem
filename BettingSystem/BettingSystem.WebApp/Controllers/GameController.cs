using BettingSystem.Core.InfrastructureContracts.Queries;
using BettingSystem.Core.Views;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BettingSystem.WebApp.Controllers
{

    [Route("api/game")]
    public class GameController : Controller
    {
        private readonly IGameQuery gameQuery;
        public GameController(IGameQuery gameQuery)
        {
            this.gameQuery = gameQuery;
        }

        [HttpGet]
        [Route("getAll")]
        public ActionResult<GameView[]> GetAllGames()
        {
            return gameQuery.WhereUnresolved().Project().ToArray();
        }
    }
}
