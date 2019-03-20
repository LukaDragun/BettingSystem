using BettingSystem.Common.Infrastructure.DatabaseContext;
using BettingSystem.Infrastructure.Entities;
using System.Linq;
using BettingSystem.Core.Views;
using BettingSystem.Core.InfrastructureContracts.Queries;
using BettingSystem.Common.Core.Enums;

namespace BettingSystem.Infrastructure.Queries
{
    public class WalletTransactionQuery: BaseQuery<WalletTransactionView, WalletTransaction>, IWalletTransactionQuery
    {
        private readonly BettingSystemDatabaseContext context;

        public WalletTransactionQuery(BettingSystemDatabaseContext context) : base(context)
        {
            this.context = context;
        }

        public override IQueryable<WalletTransactionView> Project()
        {
            return from transaction in this.inner
                   select new WalletTransactionView
                   {
                       DateTimeUpdated = transaction.UpdatedDateTime,
                       TransactionValue = transaction.TransactionValue,
                       BetId = transaction.BetId,
                       TransactionType = transaction.TransactionType
                   };
        }

        public TotalFundsView AsTotalFundsView(bool includeTransactions)
        {
            var items = this.Project().ToArray();

            return new TotalFundsView
            {
                TotalFunds = items.Sum(e => e.TransactionValue),
                Transactions = includeTransactions ? items : null,
            };
        }
    }
}
