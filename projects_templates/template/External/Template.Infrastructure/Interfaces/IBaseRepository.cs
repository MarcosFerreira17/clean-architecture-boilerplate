using System.Linq.Expressions;

namespace Template.Infrastructure.Interfaces;

public interface IBaseRepository<T>
{
    Task<IEnumerable<T>> FindAll();
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
    Task Create(T entity);
    Task Update(T entity);
    Task Delete(T entity);
}
