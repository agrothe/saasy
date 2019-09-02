using Microsoft.EntityFrameworkCore;
using SaaSy.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SaaSy.Data.Repositories
{
    public class EntityRepository
    {
        internal Type EntityType { get; set; }
        internal IDataContext DataContext { get; set; }
        public EntityRepository(IDataContext dataContext)
        {
            DataContext = dataContext;
        }

    }
    public class EntityRepository<TEntity> : EntityRepository where TEntity : class
    {
        
        internal DbSet<TEntity> DbSet { get; set; }

        public EntityRepository(IDataContext dataContext) : base(dataContext)
        {
            DbSet = DataContext.Set<TEntity>();
            EntityType = typeof(TEntity);
        }


        public virtual IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query;
        }

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "", int? take = null, int? skip = null)
        {
            IQueryable<TEntity> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if(skip.HasValue && take.HasValue)
            {
                return query
                    .Skip(skip.Value)
                    .Take(take.Value);
            }
            else
            {
                return query.ToList();
            }

            
        }

        public virtual TEntity GetByID(object id)
        {
            return DbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = DbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (DataContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }
            DbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            DbSet.Attach(entityToUpdate);
            DataContext.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
