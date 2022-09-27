using System.Linq.Expressions;

namespace Application.Interfaces;

public interface IBaseRepository<T>
{
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> expression = null,
                                    bool disableTracking = true);
    Task<IReadOnlyList<T>> FindByCondition(Expression<Func<T, bool>> expression);
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
