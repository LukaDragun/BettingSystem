using BettingSystem.Common.Infrastructure.DatabaseContext;
using BettingSystem.Infrastructure.Entities;
using BettingSystem.Core.DomainModels;
using BettingSystem.Core.InfrastructureContracts.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BettingSystem.Infrastructure.Repositories
{
    public class GameRepository : BaseRepository<GameDomainModel, Game>, IGameRepository
    {
        public GameRepository(BettingSystemDatabaseContext context) : base(context)
        {

        }

        public List<GameDomainModel> GetUnresolvedGames()
        {
            return context.Set<Game>().Where(e => !e.DateTimePlayed.HasValue).Select(e => MapEntityToDomainModel(e)).ToList();
        }

        protected override Game MapDomainModelToEntity(GameDomainModel domainModel)
        {
            return new Game
            {
                Id = domainModel.Id,
                GameType = domainModel.GameType,
                FirstTeamName = domainModel.FirstTeamName,
                SecondTeamName = domainModel.SecondTeamName,
                FirstTeamScore = domainModel.FirstTeamScore,
                SecondTeamScore = domainModel.SecondTeamScore,
                DateTimePlayed = domainModel.DateTimePlayed,
                DateTimeStarting = domainModel.DateTimeStarting,
                CreatedDateTime = domainModel.CreatedDateTime,
                UpdatedDateTime = domainModel.UpdatedDateTime,

                Coefficients = domainModel.Coefficients?.Select(e => new Coefficient
                {
                    BetType = e.BetType,
                    CoefficientValue = e.CoefficientValue
                }).ToList()
            };
        }

        protected override GameDomainModel MapEntityToDomainModel(Game entity)
        {
            return new GameDomainModel
            {
                Id = entity.Id,
                GameType = entity.GameType,
                FirstTeamName = entity.FirstTeamName,
                SecondTeamName = entity.SecondTeamName,
                FirstTeamScore = entity.FirstTeamScore,
                SecondTeamScore = entity.SecondTeamScore,
                DateTimePlayed = entity.DateTimePlayed,
                DateTimeStarting = entity.DateTimeStarting,
                CreatedDateTime = entity.CreatedDateTime,
                UpdatedDateTime = entity.UpdatedDateTime,

                Coefficients = entity.Coefficients?.Select(e => new CoefficientDomainModel
                {
                    BetType = e.BetType,
                    CoefficientValue = e.CoefficientValue
                }).ToList()
            };
        }
    }
}
