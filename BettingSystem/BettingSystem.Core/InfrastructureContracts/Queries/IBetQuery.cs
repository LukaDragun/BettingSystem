using BettingSystem.Common.Core.Enums;
using BettingSystem.Core.BaseInterfaces;
using BettingSystem.Core.Views;
using System.Collections.Generic;

namespace BettingSystem.Core.InfrastructureContracts.Queries
{
    public interface IBetQuery : IQuery<BetView>
    {
        IBetQuery WhereBetIds(IEnumerable<int> ids);
    }
}
