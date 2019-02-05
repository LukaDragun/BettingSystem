﻿using BettingSystem.Common.Infrastructure.DatabaseContext;
using BettingSystem.Common.Infrastructure.Entities;
using BettingSystem.Core.DomainModels;
using BettingSystem.Core.InfrastructureContracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace BettingSystem.Infrastructure
{
    public abstract class BaseRepository<TDomainModel , TEntity> : IBaseDomainRepository<TDomainModel>, IDisposable
        where TDomainModel : BaseDomainModel
        where TEntity : BaseEntity
        {
        private readonly BettingSystemDatabaseContext context;

        public BaseRepository()
        {
            this.context = new BettingSystemDatabaseContext();
        }

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

        public TDomainModel GetById(int id)
        {
            var entity = context.Set<TEntity>().Where(e => e.Id == id).FirstOrDefault();

            return ToDomainModel(entity);
        }

        public void Update(TDomainModel domainModel)
        {
            domainModel.SetUpdateDateTime();
            var entity = ToEntity(domainModel);
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        protected abstract TEntity ToEntity(TDomainModel domainModel);
        protected abstract TDomainModel ToDomainModel(TEntity Entity);

    }
}