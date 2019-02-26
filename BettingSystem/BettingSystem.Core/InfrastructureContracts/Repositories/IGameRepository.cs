using BettingSystem.Core.DomainModels;
using BettingSystem.Core.BaseInterfaces;
using System.Collections.Generic;

namespace BettingSystem.Core.InfrastructureContracts.Repositories
{
    public interface IGameRepository : IRepository<GameDomainModel>
    {
        List<GameDomainModel> GetUnresolvedGames();
    }
}
