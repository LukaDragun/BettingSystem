using BettingSystem.Core.ApplicationServices;
using BettingSystem.Core.InfrastructureContracts.Queries;
using BettingSystem.Core.Views;
using Microsoft.AspNetCore.Mvc;

namespace BettingSystem.WebApp.Controllers
{
    [Route("api/wallet")]
    public class WalletController : Controller
    {
        private readonly WalletTransactionService walletTransactionService;
        private readonly IWalletTransactionQuery walletTransactionQuery;

        public WalletController(WalletTransactionService walletTransactionService, IWalletTransactionQuery walletTransactionQuery)
        {
            this.walletTransactionService = walletTransactionService;
            this.walletTransactionQuery = walletTransactionQuery;
        }

        [HttpPost]
        [Route("addFunds")]
        public void AddFunds(int value)
        {
           walletTransactionService.AddFunds(value);
        }

        [HttpGet]
        [Route("")]
        public ActionResult<TotalFundsView> GetTotalFunds(bool includeTransactions = true)
        {
            return walletTransactionQuery.AsTotalFundsView(includeTransactions);
        }
    }
}