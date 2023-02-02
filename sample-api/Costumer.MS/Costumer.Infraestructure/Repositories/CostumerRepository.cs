using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Costumer.Domain.Entities;
using Costumer.Domain.Interfaces;
using Costumer.Infraestructure.DataContext;

namespace Costumer.Infraestructure.Repositories;

public class CostumerRepository : ICostumerRepository
{
    private readonly CostumerDbContext _context;
    public CostumerRepository(CostumerDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Person>> FindAll()
    {
        IQueryable<Person> query = _context.Set<Person>();

        return await query.AsNoTracking().ToListAsync();
    }
    public IQueryable<Person> FindByCondition(Expression<Func<Person, bool>> expression)
    => _context.Set<Person>().Where(expression).AsNoTracking();

    public async Task Create(Person entity)
    {
        await _context.Set<Person>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }
    public async Task Update(Person entity)
    {
        _context.Set<Person>().Update(entity);
        await _context.SaveChangesAsync();
    }
    public async Task Delete(Person entity)
    {
        _context.Set<Person>().Remove(entity);
        await _context.SaveChangesAsync();
    }
}