using BettingSystem.Common.Infrastructure.DatabaseContext;
using BettingSystem.Infrastructure.Entities;
using BettingSystem.Core.DomainModels;
using BettingSystem.Core.InfrastructureContracts;

namespace BettingSystem.Infrastructure.Repositories
{
    public class GameRepository : BaseRepository<GameDomainModel, Game> , IGameRepository
    {
        public GameRepository(BettingSystemDatabaseContext context) : base(context)
        {

        }

        protected override Game ToEntity(GameDomainModel domainModel)
        {
            return new Game
            {
                Id = domainModel.Id,
                UpdatedDateTime = domainModel.UpdatedDateTime,
                CreatedDateTime = domainModel.CreatedDateTime,
            };
        }
    }
}
