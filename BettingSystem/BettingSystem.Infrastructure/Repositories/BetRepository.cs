using BettingSystem.Common.Infrastructure.DatabaseContext;
using BettingSystem.Core.DomainModels;
using BettingSystem.Core.InfrastructureContracts.Repositories;
using BettingSystem.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BettingSystem.Infrastructure.Repositories
{
    public class BetRepository : BaseRepository<BetDomainModel, Bet> , IBetRepository
    {
        public BetRepository(BettingSystemDatabaseContext context) : base(context)
        {

        }

        public List<BetDomainModel> GetUnresolvedBets()
        {
            return context.Set<Bet>().Include(e => e.BetCoefficients).ThenInclude(bc => bc.Coefficient).Where(e => !e.IsResolved).Select(e => MapEntityToDomainModel(e)).ToList();
        }

        public List<CoefficientDomainModel> GetCoefficientsForBet(int[] coefficientIds)
        {
            return context.Set<Coefficient>().Where(e => coefficientIds.Contains(e.Id)).Select(e => new CoefficientDomainModel {
                CoefficientValue = e.CoefficientValue,
                BetType = e.BetType,
                Id = e.Id
            }).ToList();
        }

        protected override Bet MapDomainModelToEntity(BetDomainModel domainModel)
        {
            return new Bet
            {
                Id = domainModel.Id,
                IsResolved = domainModel.IsResolved,
                CreatedDateTime = domainModel.CreatedDateTime,
                UpdatedDateTime = domainModel.UpdatedDateTime,

                BetCoefficients = domainModel.Coefficients?.Select(e => new BetCoefficient
                {
                    CoefficientId = e.Id
                }).ToList()
            };
        }

        protected override BetDomainModel MapEntityToDomainModel(Bet entity)
        {
            return new BetDomainModel
            {
                Id = entity.Id,
                IsResolved = entity.IsResolved,
                CreatedDateTime = entity.CreatedDateTime,
                UpdatedDateTime = entity.UpdatedDateTime,

                Coefficients = entity.BetCoefficients?.Where(e => e.Coefficient != null).Select(e => new CoefficientDomainModel
                {
                    Id = e.Coefficient.Id,
                    BetType = e.Coefficient.BetType,
                    CoefficientValue = e.Coefficient.CoefficientValue,
                    CreatedDateTime = entity.CreatedDateTime,
                    UpdatedDateTime = entity.UpdatedDateTime
                }).ToList()
            };
        }
    }
}
