using Template.Application.Interfaces;
using Template.Domain.Entities;
using Template.Infrastructure.Common;
using Template.Infrastructure.DataContext;

namespace Template.Infrastructure.Repositories;

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
