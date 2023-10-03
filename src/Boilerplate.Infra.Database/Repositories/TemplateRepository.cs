using Boilerplate.Domain.Entities;
using Boilerplate.Infra.Database.DataContext;
using Boilerplate.Infra.Database.Repositories.Interfaces;

namespace Boilerplate.Infra.Database.Repositories;

public class BoilerplateRepository : BaseRepository<BoilerplateEntity, ApplicationDbContext>, IBoilerplateRepository
{
    public BoilerplateRepository(ApplicationDbContext context) : base(context) { }
}