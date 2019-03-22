using BettingSystem.Common.Infrastructure.DatabaseContext;
using BettingSystem.Infrastructure.Entities;
using System.Linq;
using BettingSystem.Core.Views;
using BettingSystem.Core.InfrastructureContracts.Queries;
using BettingSystem.Common.Core.Enums;
using System;
using System.Collections.Generic;

namespace BettingSystem.Infrastructure.Queries
{
    public class BetQuery : BaseQuery<BetView, Bet>, IBetQuery
    {
        private readonly BettingSystemDatabaseContext context;

        public BetQuery(BettingSystemDatabaseContext context) : base(context)
        {
            this.context = context;
        }

        BetQuery(BetQuery previous, IQueryable<Bet> inner) : base(inner)
        {
            this.context = previous.context;
        }

        public IBetQuery WhereBetIds(IEnumerable<int> ids)
        {
            return new BetQuery(this, this.inner.Where(e => ids.Contains(e.Id)));
        }

        public override IQueryable<BetView> Project()
        {
            return from bet in this.inner
                   join bc in this.context.Set<BetCoefficient>() on bet.Id equals bc.BetId
                   join coefficient in this.context.Set<Coefficient>() on bc.CoefficientId equals coefficient.Id
                   join game in this.context.Set<Game>() on coefficient.GameId equals game.Id
                   group new { coefficient, game } by new { bet.Id, bet.IsResolved, bet.CreatedDateTime } into betGroups
                   let betValue = -context.Set<WalletTransaction>().FirstOrDefault(e => e.TransactionType == TransactionType.Bet && e.BetId == betGroups.Key.Id).TransactionValue
                   select new BetView
                   {
                       Id = betGroups.Key.Id,
                       IsResolvable = betGroups.All(e => e.game.DateTimePlayed.HasValue),
                       IsResolved = betGroups.Key.IsResolved,
                       BetValue = betValue,
                       CreatedDateTime = betGroups.Key.CreatedDateTime,
                       Games = betGroups.Select(e => new GameResolutionView
                       {
                           GameType = e.game.GameType,
                           FirstTeamName = e.game.FirstTeamName,
                           SecondTeamName = e.game.SecondTeamName,
                           FirstTeamScore = e.game.FirstTeamScore,
                           SecondTeamScore = e.game.SecondTeamScore,
                           DateTimeStarting = e.game.DateTimeStarting,
                           DateTimePlayed = e.game.DateTimePlayed,
                           BetType = e.coefficient.BetType,
                           CoefficientValue = e.coefficient.CoefficientValue,
                           IsGuessed = IsBetGuessed(e.coefficient.BetType, e.game.FirstTeamScore, e.game.SecondTeamScore)
                       }).ToArray()
                   };
        }

        private bool IsBetGuessed(BetType betType, int? firstTeamScore, int? secondTeamScore)
        {
            if (!firstTeamScore.HasValue || !secondTeamScore.HasValue)
                return false;

            switch (betType)
            {
                case BetType.One:
                    return firstTeamScore.Value > secondTeamScore.Value;
                case BetType.OneTwo:
                    return firstTeamScore.Value != secondTeamScore.Value;
                case BetType.Two:
                    return firstTeamScore.Value < secondTeamScore.Value;
                case BetType.X:
                    return firstTeamScore.Value == secondTeamScore.Value;
                case BetType.XOne:
                    return firstTeamScore.Value >= secondTeamScore.Value;
                case BetType.XTwo:
                    return firstTeamScore.Value <= secondTeamScore.Value;
                default:
                    throw new Exception("Bet type not supported");
            }
        }

    }
}
