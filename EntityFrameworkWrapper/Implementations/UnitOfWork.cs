using EntityFrameworkWrapper.Factories;
using EntityFrameworkWrapper.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkWrapper.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext Context;
        private readonly Dictionary<Type, object> Repositories = new Dictionary<Type, object>();

        public UnitOfWork(DbContext dbContext)
        {
            Context = dbContext;

        }

        public UnitOfWork(IDbContextFactory contextFactory)
            : this(contextFactory.Create())
        {
        }


        public IRepository<TEntity> RepositoryOf<TEntity>() where TEntity : class
        {
            var t = typeof(TEntity);

            object value = null;
            if (!Repositories.TryGetValue(t, out value))
            {
                var repository = new Repository<TEntity>(Context.Set<TEntity>());
                Repositories.Add(t, repository);
                return repository;
            }
            return (IRepository<TEntity>)value;
        }


        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Context.Dispose();
            }
        }
    }
}
