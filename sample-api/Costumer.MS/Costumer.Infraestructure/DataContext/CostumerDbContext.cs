using Microsoft.EntityFrameworkCore;
using Costumer.Domain.Entities;
using Costumer.Infraestructure.Maps;

namespace Costumer.Infraestructure.DataContext;

public class CostumerDbContext : DbContext
{
    public DbSet<Person> Person { get; set; }
    public CostumerDbContext(DbContextOptions<CostumerDbContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PersonMap());
    }
}
