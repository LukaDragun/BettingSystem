using BettingSystem.Common.Core.Enums;
using BettingSystem.Core.InfrastructureContracts.Queries;
using BettingSystem.Core.Views;
using Microsoft.AspNetCore.Mvc;

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
        [Route("")]
        public ActionResult<GameOfferView> GetAllGames(GameType? sportType = null)
        {
            var query = gameQuery;

            if (sportType.HasValue)
                query = gameQuery.WhereGameType(sportType.Value);


            return query.WhereUnresolved().AsGameOfferView();
        }
    }
}
