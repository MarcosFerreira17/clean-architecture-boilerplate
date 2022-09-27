using Application.Interfaces;
using Domain.Entities;
using Infrastructure.DataContext;

namespace Infrastructure.Repositories;

public class TemplateRepository : BaseRepository<Entity, ApplicationDbContext>, ITemplateRepository
{
    public TemplateRepository(ApplicationDbContext context) : base(context) { }
}
