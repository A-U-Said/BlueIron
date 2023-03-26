using App.Repository.Context;
using App.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace App.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext RepositoryContext { get; set; }
        protected readonly DbSet<T> Set;
        protected RepositoryBase(RepositoryContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
            Set = RepositoryContext.Set<T>();
        }

        public async Task<IQueryable<T>> GetAll()
        {
            return await Task.Run(() => Set);
        }

        public async Task Create(T entity)
        {
            await Task.Run(() => Set.Add(entity));
        }

        public async Task Delete(T entity)
        {
            await Task.Run(() => Set.Remove(entity));
        }

        public async Task<IQueryable<T>> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return await Task.Run(() => Set.Where(expression));
        }

        public async Task Update(T entity)
        {
            await Task.Run(() => Set.Update(entity));
        }

        public async Task SaveChanges()
        {
            await RepositoryContext.SaveChangesAsync();
        }
    }
}
