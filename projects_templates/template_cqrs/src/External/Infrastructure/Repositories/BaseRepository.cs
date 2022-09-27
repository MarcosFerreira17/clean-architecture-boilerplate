using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Infrastructure.DataContext;
using Domain.Common;
using Application.Interfaces;

namespace Infrastructure.Repositories;

public abstract class BaseRepository<T, TContext> : IBaseRepository<T> where T : EntityBase<long> where TContext : ApplicationDbContext
{
    private readonly TContext _context;

    protected BaseRepository(TContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async virtual Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async virtual Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> expression = null, bool disableTracking = true)
    {
        IQueryable<T> query = _context.Set<T>();
        if (disableTracking) query = query.AsNoTracking();

        if (expression != null) query = query.Where(expression);

        return await query.ToListAsync();
    }

    public async virtual Task<IReadOnlyList<T>> FindByCondition(Expression<Func<T, bool>> expression)
    {
        return await _context.Set<T>().Where(expression).ToListAsync();
    }

    public async virtual Task<T> AddAsync(T entity)
    {
        _context.Set<T>().Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async virtual Task UpdateAsync(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async virtual Task DeleteAsync(T entity)
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }
}
