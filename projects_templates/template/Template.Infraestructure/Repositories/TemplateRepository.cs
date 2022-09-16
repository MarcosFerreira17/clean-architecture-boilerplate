using Template.Domain.Entities;
using Template.Domain.Interfaces;
using Template.Infraestructure.DataContext;

namespace Template.Infraestructure.Repositories;

public class TemplateRepository : BaseRepository<TemplateEntity, TemplateDbContext>, ITemplateRepository
{
    public TemplateRepository(TemplateDbContext context) : base(context) { }
}