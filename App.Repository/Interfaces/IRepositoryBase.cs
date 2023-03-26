using System.Linq.Expressions;

namespace App.Repository.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<IQueryable<T>> GetAll();
        Task<IQueryable<T>> GetByCondition(Expression<Func<T, bool>> expression);
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task SaveChanges();
    }
}
