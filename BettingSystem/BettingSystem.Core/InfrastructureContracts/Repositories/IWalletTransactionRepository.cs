using BettingSystem.Core.BaseInterfaces;
using BettingSystem.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BettingSystem.Core.InfrastructureContracts.Repositories
{
    public interface IWalletTransactionRepository : IRepository<WalletTransactionDomainModel>
    {
    }
}
