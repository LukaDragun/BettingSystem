using BettingSystem.Common.Infrastructure.DatabaseContext;
using BettingSystem.Infrastructure.Entities;
using BettingSystem.Core.DomainModels;
using BettingSystem.Core.InfrastructureContracts.Repositories;
using System.Collections.Generic;

namespace BettingSystem.Infrastructure.Repositories
{
    public class GameRepository : BaseRepository<GameDomainModel, Game> , IGameRepository
    {
        public GameRepository(BettingSystemDatabaseContext context) : base(context)
        {

        }

        protected override Game CopyDomainModelToEntity(ref Game entity, GameDomainModel domainModel)
        {
            entity.Id = domainModel.Id;
            entity.GameType = domainModel.GameType;
            entity.FirstTeamName = domainModel.FirstTeamName;
            entity.SecondTeamName = domainModel.SecondTeamName;
            entity.FirstTeamScore = domainModel.FirstTeamScore;
            entity.SecondTeamScore = domainModel.SecondTeamScore;
            entity.DateTimePlayed = domainModel.DateTimePlayed;
            entity.DateTimeStarting = domainModel.DateTimeStarting;
            entity.CreatedDateTime = domainModel.CreatedDateTime;
            entity.UpdatedDateTime = domainModel.UpdatedDateTime;

            entity.Coefficients = new List<Coefficient>();

            foreach (var coeffiecient in domainModel.Coefficients)
            {
                var coefficientEntity = new Coefficient()
                {
                    GameId = entity.Id,
                    BetType = coeffiecient.BetType,
                    CoefficientValue = coeffiecient.CoefficientValue
                };

                entity.Coefficients.Add(coefficientEntity);
            }

            return entity;
        }
    }
}
