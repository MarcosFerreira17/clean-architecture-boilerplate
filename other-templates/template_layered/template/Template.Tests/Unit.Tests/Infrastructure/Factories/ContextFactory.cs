using System;
using Microsoft.EntityFrameworkCore;
using Template.Infrastructure.DataContext;

namespace Unit.Tests.Infrastructure.Factories;

public static class ContextFactory
{
    public static TemplateDbContext Create()
    {
        var options = new DbContextOptionsBuilder<TemplateDbContext>()
                        .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

        return new TemplateDbContext(options);
    }
}
