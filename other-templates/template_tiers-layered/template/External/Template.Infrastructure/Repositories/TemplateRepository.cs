using Template.Domain.Entities;
using Template.Infrastructure.DataContext;
using Template.Infrastructure.Repositories.Interfaces;

namespace Template.Infrastructure.Repositories;

public class TemplateRepository : BaseRepository<TemplateEntity, TemplateDbContext>, ITemplateRepository
{
    public TemplateRepository(TemplateDbContext context) : base(context) { }
}