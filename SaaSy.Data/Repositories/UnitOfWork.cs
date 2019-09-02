using SaaSy.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SaaSy.Data.Repositories
{
    public class UnitOfWork : IDisposable
    {
        internal IDataContext DataContext { get; set; }
        internal IList<EntityRepository> EntityRepositories;
        private IServiceProvider Services { get; set; }

        private bool disposed = false;

        public UnitOfWork(IServiceProvider services)
        {
            Services = services;
            DataContext = (IDataContext)Services.GetService(typeof(IDataContext));
            EntityRepositories = new List<EntityRepository>();
        }

        public EntityRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            var repository = EntityRepositories.FirstOrDefault(x=>x.EntityType == typeof(TEntity));
            
            if(repository == null)
            {
                repository = new EntityRepository<TEntity>(DataContext);
                EntityRepositories.Add(repository);
            }

            return (EntityRepository<TEntity>)repository;
        }

        public async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            return await DataContext.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await DataContext.SaveChangesAsync(cancellationToken);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    DataContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
