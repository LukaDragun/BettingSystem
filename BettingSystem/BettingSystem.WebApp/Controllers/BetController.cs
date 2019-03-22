using BettingSystem.Core.ApplicationServices;
using BettingSystem.Core.InfrastructureContracts.Queries;
using BettingSystem.Core.TransferObjects;
using BettingSystem.Core.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BettingSystem.WebApp.Controllers
{
    [Route("api/bet")]
    public class BetController : Controller
    {
        private readonly BetService betService;
        private readonly IBetQuery betQuery;

        public BetController(BetService betService, IBetQuery betQuery)
        {
            this.betService = betService;
            this.betQuery = betQuery;
        }

        [HttpPost]
        [Route("")]
        public void PlaceBet([FromBody]BetDto dto)
        {
            betService.PlaceBet(dto);
        }

        [HttpGet]
        [Route("")]
        public ActionResult<BetView[]> GetBets()
        {
            return betQuery.Project().OrderBy(e => e.CreatedDateTime).ToArray();
        }

        [HttpGet]
        [Route("{betId}")]
        public ActionResult<BetView> GetBet(int betId)
        {
            return betQuery.Project().FirstOrDefault(e => e.Id == betId);
        }
    }
}