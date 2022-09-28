using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Common;
using Infrastructure.DataContext;

namespace Infrastructure.Repositories;

public class TemplateRepository : BaseRepository<Entity, ApplicationDbContext>, ITemplateRepository<long>
{
    private readonly ApplicationDbContext _context;
    public TemplateRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Entity> GetByIdAsync(long id)
    {
        return await _context.Set<Entity>().FindAsync(id);
    }
}
