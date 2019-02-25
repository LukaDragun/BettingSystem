using BettingSystem.Core.DomainModels;
using BettingSystem.Core.BaseInterfaces;

namespace BettingSystem.Core.InfrastructureContracts.Repositories
{
    public interface IGameRepository : IRepository<GameDomainModel>
    {
    }
}
