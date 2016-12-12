
namespace BusTicketSystem.Data.Repositories
{
    using BusTicketSystem.Data.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Data.Entity;
    using System.Linq;
    using EntityFramework.Extensions;
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly BusTicketSystemContext context;
        private readonly IDbSet<TEntity> set;
       
        public Repository(IDbSet<TEntity> set )
        {
           this.set = set;
          
        }
        public void Add(TEntity entity)
        {
            this.set.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            this.set.Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        { 
            this.set.Delete(entities.AsQueryable());
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this.set;
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return this.set.Where(predicate);
        }

    
        public TEntity GetById(int id)
        {
            
            return this.set.Find(id);
        }

        public TEntity FirstOrDefault()
        {
            return this.set.FirstOrDefault();
        }

        public TEntity FirstOrDefaultWhere(Expression<Func<TEntity, bool>> predicate)
        {
            return this.set.FirstOrDefault(predicate);
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        
        {
            return this.set.Where(predicate);
        }
    }

}

