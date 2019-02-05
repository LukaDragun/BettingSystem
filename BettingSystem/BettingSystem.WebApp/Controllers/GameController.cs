using BettingSystem.Core.DomainModels;
using BettingSystem.Core.InfrastructureContracts;
using Microsoft.AspNetCore.Mvc;

namespace BettingSystem.WebApp.Controllers
{

    [Route("api/game")]
    public class GameController : Controller
    {
        private readonly IGameRepository gameRepository;
        public GameController(IGameRepository gameRepository)
        {
            this.gameRepository = gameRepository;
        }

        [HttpGet("")]
        public ActionResult<BaseDomainModel> GetAllGames()
        {
            return gameRepository.GetById(3);
        }
    }
}
