using BettingSystem.Common.Infrastructure.DatabaseContext;
using BettingSystem.Infrastructure.Entities;
using BettingSystem.Core.DomainModels;
using BettingSystem.Core.InfrastructureContracts;

namespace BettingSystem.Infrastructure.Repositories
{
    public class GameRepository : BaseRepository<BaseDomainModel, Game> , IGameRepository
    {
        public GameRepository(BettingSystemDatabaseContext context) : base(context)
        {

        }

        protected override Game ToEntity(BaseDomainModel domainModel)
        {
            return new Game
            {
                Id = domainModel.Id,
                UpdatedDateTime = domainModel.UpdatedDateTime,
                CreatedDateTime = domainModel.CreatedDateTime,
            };
        }

        protected override BaseDomainModel ToDomainModel(Game entity)
        {
            return new BaseDomainModel
            {
                Id = entity.Id,
                UpdatedDateTime = entity.UpdatedDateTime,
                CreatedDateTime = entity.CreatedDateTime,
            };
        }
    }
}
