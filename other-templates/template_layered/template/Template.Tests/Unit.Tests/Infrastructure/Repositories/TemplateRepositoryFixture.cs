using System.Collections.Generic;
using Template.Domain.Entities;

namespace Unit.Tests.Infrastructure.Repositories;

public static class TemplateRepositoryFixture
{
    public static List<TemplateEntity> AllEntities()
    {
        return new List<TemplateEntity>{
            new TemplateEntity{
                Id = 1,
                ExampleString = "Need To Test this proj",
            },
            new TemplateEntity{
                Id = 2,
                ExampleString= "Cook Food",
            },
            new TemplateEntity{
                Id = 3,
                ExampleString= "Play Games",
            }
        };
    }

    public static List<TemplateEntity> EmptyListEntities()
    {
        return new List<TemplateEntity>();
    }

    public static TemplateEntity NewEntity()
    {
        return new TemplateEntity
        {
            Id = 1,
            ExampleString = "We create a new entity mockdb"
        };
    }
}