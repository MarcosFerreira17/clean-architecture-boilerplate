using Boilerplate.Domain.Entities;
using Boilerplate.Infrastructure.DataContext;
using Boilerplate.Infrastructure.Repositories.Interfaces;

namespace Boilerplate.Infrastructure.Repositories;

public class BoilerplateRepository : BaseRepository<BoilerplateEntity, ApplicationDbContext>, IBoilerplateRepository
{
    public BoilerplateRepository(ApplicationDbContext context) : base(context) { }
}