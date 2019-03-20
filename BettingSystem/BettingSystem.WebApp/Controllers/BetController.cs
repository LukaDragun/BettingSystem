using BettingSystem.Core.ApplicationServices;
using BettingSystem.Core.TransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BettingSystem.WebApp.Controllers
{
    [Route("api/bet")]
    public class BetController : Controller
    {
        private readonly BetService betService;

        public BetController(BetService betService)
        {
            this.betService = betService;
        }

        [HttpPost]
        [Route("placeBet")]
        public void PlaceBet([FromBody]BetDto dto)
        {
            betService.PlaceBet(dto);
        }
    }
}