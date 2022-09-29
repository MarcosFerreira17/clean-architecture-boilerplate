using Microsoft.EntityFrameworkCore;
using Template.Infrastructure.DataContext;

namespace Template.Tests.Helpers.Factories;

public static class ContextFactory
{
    public static TemplateDbContext Create()
    {
        var options = new DbContextOptionsBuilder<TemplateDbContext>()
                        .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

        return new TemplateDbContext(options);
    }
}
