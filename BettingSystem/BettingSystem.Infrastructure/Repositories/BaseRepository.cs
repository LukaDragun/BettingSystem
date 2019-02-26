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
        where TEntity : BaseEntity
    {
        protected readonly BettingSystemDatabaseContext context;

        internal BaseRepository(BettingSystemDatabaseContext context)
        {
            this.context = context;
        }

        public TDomainModel GetById(int id)
        {
            var entity = context.Set<TEntity>().FirstOrDefault(e => e.Id == id);
            var domainModel = MapEntityToDomainModel(entity);
            return domainModel;
        }

        public void Create(TDomainModel domainModel)
        {
            var entity = MapDomainModelToEntity(domainModel);
            context.Add(entity);
            context.SaveChanges();
        }

        public void CreateMany(ICollection<TDomainModel> domainModels)
        {
            var entities = new List<TEntity>();

            foreach(var domainModel in domainModels) {
                var entity = MapDomainModelToEntity(domainModel);
                entities.Add(entity);
            }
            context.AddRange(entities);
            context.SaveChanges();
        }

        public void UpdateMany(ICollection<TDomainModel> domainModels)
        {
            var entities = new List<TEntity>();

            foreach (var domainModel in domainModels)
            {
                var entity = MapDomainModelToEntity(domainModel);
                context.Entry(entity).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public void Update(TDomainModel domainModel)
        {
            var entity = MapDomainModelToEntity(domainModel);
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        protected abstract TEntity MapDomainModelToEntity(TDomainModel domainModel);
        protected abstract TDomainModel MapEntityToDomainModel(TEntity entity);

    }
}
