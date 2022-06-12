using Microsoft.EntityFrameworkCore;
using OrderProject.DataAccess.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.DataAccess.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly OrderDbContext dbContext;
        internal DbSet<TEntity> dbSet;

        public Repository(OrderDbContext OrderDbContext)
        {
            this.dbContext = OrderDbContext;
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            try
            {
                await dbContext.Set<TEntity>().AddAsync(entity);
                await dbContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = GetAllAsync().Where(predicate);
            return includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        public IQueryable<TEntity> GetAllAsync()
        {
            try
            {
                return dbContext.Set<TEntity>();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
