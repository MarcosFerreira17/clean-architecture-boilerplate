using System.Collections.Generic;
using Template.Domain.Dtos;

namespace Unit.Tests.Presentation.Controllers;

public static class TemplateControllerFixture
{
    public static List<TemplateDto> AllEntities()
    {
        return new List<TemplateDto>{
            new TemplateDto{
                Id = 1,
                ExampleString = "Need To Test this proj",
            },
            new TemplateDto{
                Id = 2,
                ExampleString= "Cook Food",
            },
            new TemplateDto{
                Id = 3,
                ExampleString= "Play Games",
            }
        };
    }

    public static List<TemplateDto> EmptyListEntities()
    {
        return new List<TemplateDto>();
    }

    public static TemplateDto NewEntity()
    {
        return new TemplateDto
        {
            Id = 1,
            ExampleString = "We create a new entity mockdb"
        };
    }
}