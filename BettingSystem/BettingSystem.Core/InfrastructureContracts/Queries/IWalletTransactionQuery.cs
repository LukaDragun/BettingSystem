using BettingSystem.Core.BaseInterfaces;
using BettingSystem.Core.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace BettingSystem.Core.InfrastructureContracts.Queries
{
    public interface IWalletTransactionQuery : IQuery<WalletTransactionView>
    {
        TotalFundsView AsTotalFundsView();
    }
}
