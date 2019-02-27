using BettingSystem.Common.Infrastructure.DatabaseContext;
using BettingSystem.Core.DomainModels;
using BettingSystem.Core.InfrastructureContracts.Repositories;
using BettingSystem.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BettingSystem.Infrastructure.Repositories
{
    public class WalletTransactionRepository : BaseRepository<WalletTransactionDomainModel, WalletTransaction> , IWalletTransactionRepository
    {
        public WalletTransactionRepository(BettingSystemDatabaseContext context) : base(context)
        {

        }

        protected override WalletTransaction MapDomainModelToEntity(WalletTransactionDomainModel domainModel)
        {
            return new WalletTransaction
            {
                Id = domainModel.Id,

                CreatedDateTime = domainModel.CreatedDateTime,
                UpdatedDateTime = domainModel.UpdatedDateTime,
                TransactionValue = domainModel.TransactionValue,
                TransactionType = domainModel.TransactionType,

                BetId = domainModel.Bet == null ? (int?)null : domainModel.Bet.Id
            };
        }

        protected override WalletTransactionDomainModel MapEntityToDomainModel(WalletTransaction entity)
        {
            return new WalletTransactionDomainModel
            {
                Id = entity.Id,

                CreatedDateTime = entity.CreatedDateTime,
                UpdatedDateTime = entity.UpdatedDateTime,
                TransactionValue = entity.TransactionValue,
                TransactionType = entity.TransactionType,

                Bet = entity.Bet == null ? null : new BetDomainModel
                {
                    Id = entity.Bet.Id,
                    IsResolved = entity.Bet.IsResolved,
                    CreatedDateTime = entity.Bet.CreatedDateTime,
                    UpdatedDateTime = entity.Bet.UpdatedDateTime,
                }
            };
        }
    }
}
