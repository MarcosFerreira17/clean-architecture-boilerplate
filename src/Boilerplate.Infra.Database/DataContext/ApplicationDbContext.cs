using Microsoft.EntityFrameworkCore;
using Boilerplate.Domain.Entities;

namespace Boilerplate.Infra.Database.DataContext;

public class ApplicationDbContext : DbContext
{
    public DbSet<BoilerplateEntity> Boilerplate { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}
