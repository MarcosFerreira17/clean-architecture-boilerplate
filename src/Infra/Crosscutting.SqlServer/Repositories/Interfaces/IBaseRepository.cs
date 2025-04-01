using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Crosscutting.SqlServer.Repositories.Interfaces;

public interface IBaseRepository<T> where T : class
{
    IQueryable<T> Query(Expression<Func<T, bool>> predicate = null,
                                Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                                bool enableTracking = true);
    T Insert(T entity);

    T InsertNotExists(Expression<Func<T, bool>> predicate, T entity);

    void Update(T entity);

    void Delete(T entity);

    void Delete(IEnumerable<T> entities);

    bool SaveChanges();
}