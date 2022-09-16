using Microsoft.EntityFrameworkCore;
using Template.Domain.Entities;

namespace Template.Infraestructure.DataContext;

public class TemplateDbContext : DbContext
{
    public DbSet<TemplateEntity> Template { get; set; }
    public TemplateDbContext(DbContextOptions<TemplateDbContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}
