using EntityFrameworkWrapper.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkWrapper.Implementations
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> DbSet;
        private readonly List<Expression<Func<TEntity, object>>> IncludePathExpressions;

        public Repository(DbSet<TEntity> dbSet)
        {
            DbSet = dbSet;
            IncludePathExpressions = new List<Expression<Func<TEntity, object>>>();
        }

        public IRepository<TEntity> Include(Expression<Func<TEntity, object>> pathExpression)
        {
            IncludePathExpressions.Add(pathExpression);
            return this;
        }

        public IQueryable<TEntity> FindAll()
        {
            return GetQueryable();
        }

        public void Add(TEntity newEntity)
        {
            DbSet.Add(newEntity);
        }

        public void Remove(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        private IQueryable<TEntity> GetQueryable()
        {
            if (IncludePathExpressions.Count > 0)
            {
                IQueryable<TEntity> returnQuery = DbSet;
                foreach (var pathExpression in IncludePathExpressions)
                {
                    returnQuery = returnQuery.Include(pathExpression);
                }
                IncludePathExpressions.Clear();

                return returnQuery;
            }
            else
            {
                return DbSet;
            }
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            DbSet.AddRange(entities);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            DbSet.RemoveRange(entities);
        }
    }
}
