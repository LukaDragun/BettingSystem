using BettingSystem.Common.Infrastructure.DatabaseContext;
using BettingSystem.Infrastructure.Entities;
using BettingSystem.Core.DomainModels;
using BettingSystem.Core.InfrastructureContracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BettingSystem.Infrastructure
{
    public abstract class BaseRepository<TDomainModel , TEntity> : IBaseRepository<TDomainModel>, IDisposable
        where TDomainModel : BaseDomainModel
        where TEntity : BaseEntity
        {
        private readonly BettingSystemDatabaseContext context;

        internal BaseRepository(BettingSystemDatabaseContext context)
        {
            this.context = context;
        }

        public void Dispose()
        {
            this.Dispose();
        }

        public void Create(TDomainModel domainModel)
        {
            domainModel.SetCreateDateTime();
            var entity = ToEntity(domainModel);
            context.Entry(entity).State = EntityState.Added;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = context.Set<TEntity>().FirstOrDefault(e => e.Id == id);
            context.Entry(entity).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public void Update(TDomainModel domainModel)
        {
            domainModel.SetUpdateDateTime();
            var entity = ToEntity(domainModel);
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        protected abstract TEntity ToEntity(TDomainModel domainModel);

    }
}
