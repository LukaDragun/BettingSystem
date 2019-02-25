using BettingSystem.Common.Infrastructure.DatabaseContext;
using BettingSystem.Infrastructure.Entities;
using BettingSystem.Core.DomainModels;
using BettingSystem.Core.BaseInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;

namespace BettingSystem.Infrastructure
{
    public abstract class BaseRepository<TDomainModel, TEntity> : IRepository<TDomainModel>
        where TDomainModel : BaseDomainModel
        where TEntity : BaseEntity , new()
    {
        private readonly BettingSystemDatabaseContext context;

        internal BaseRepository(BettingSystemDatabaseContext context)
        {
            this.context = context;
        }

        public void Create(TDomainModel domainModel)
        {
            domainModel.SetCreateDateTime();
            var entity = new TEntity();
            entity = CopyDomainModelToEntity(ref entity, domainModel);
            context.Add(entity);
            context.SaveChanges();
        }

        public void CreateMany(ICollection<TDomainModel> domainModels)
        {
            var entities = new List<TEntity>();

            foreach(var domainModel in domainModels) {
                domainModel.SetCreateDateTime();
                var entity = new TEntity();
                entity = CopyDomainModelToEntity(ref entity, domainModel);
                entities.Add(entity);
            }
            context.AddRange(entities);
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
            var entity = context.Set<TEntity>().FirstOrDefault(e => e.Id == domainModel.Id);
            entity = CopyDomainModelToEntity(ref entity, domainModel);
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        protected abstract TEntity CopyDomainModelToEntity(ref TEntity entity, TDomainModel domainModel);

    }
}
