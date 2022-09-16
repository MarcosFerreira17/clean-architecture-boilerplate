using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Template.Domain.Common;
using Template.Infraestructure.DataContext;

namespace Template.Infraestructure.Repositories;

public abstract class BaseRepository<T, TContext> : IBaseRepository<T> where T : class where TContext : TemplateDbContext
{
    protected readonly TContext _context;
    protected BaseRepository(TContext context)
    {
        _context = context;
    }

    public async virtual Task<IEnumerable<T>> FindAll()
    {
        IQueryable<T> query = _context.Set<T>();

        return await query.AsNoTracking().ToListAsync();
    }
    public virtual IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
    => _context.Set<T>().Where(expression).AsNoTracking();

    public async virtual Task Create(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }
    public async virtual Task Update(T entity)
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
    }
    public async virtual Task Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }
}