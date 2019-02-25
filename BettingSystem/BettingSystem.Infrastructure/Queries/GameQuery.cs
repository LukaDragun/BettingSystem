using BettingSystem.Common.Infrastructure.DatabaseContext;
using BettingSystem.Infrastructure.Entities;
using System.Linq;
using BettingSystem.Core.Views;
using BettingSystem.Core.InfrastructureContracts.Queries;
using BettingSystem.Common.Core.Enums;

namespace BettingSystem.Infrastructure.Queries
{
    public class GameQuery : BaseQuery<GameView, Game>, IGameQuery
    {
        private readonly BettingSystemDatabaseContext context;

        public GameQuery(BettingSystemDatabaseContext context) : base(context)
        {
            this.context = context;
        }

        GameQuery(GameQuery previous, IQueryable<Game> inner) : base(inner)
        {
            this.context = previous.context;
        }

        public IGameQuery WhereUnresolved() {
            return new GameQuery(this, this.inner.Where(e => !e.DateTimePlayed.HasValue));
        }

        public IGameQuery WhereGameType(SportType type)
        {
            return new GameQuery(this, this.inner.Where(e => e.GameType == type));
        }

        public override IQueryable<GameView> Project()
        {
            return from game in this.inner
                   select new GameView
                   {
                       Id = game.Id,
                       FirstTeamName = game.FirstTeamName,
                       SecondTeamName = game.SecondTeamName,
                       FirstTeamScore = game.FirstTeamScore,
                       SecondTeamScore = game.SecondTeamScore,
                       DateTimeStarting = game.DateTimeStarting,
                       DateTimePlayed = game.DateTimePlayed,
                       Coefficients = (from coefficient in context.Set<Coefficient>()
                                      where coefficient.GameId == game.Id
                                      select new CoefficientView
                                      {
                                          Id = coefficient.Id,
                                          BetType = coefficient.BetType,
                                          CoefficientValue = coefficient.CoefficientValue
                                      }).ToList()
                   };
        }
    }
}