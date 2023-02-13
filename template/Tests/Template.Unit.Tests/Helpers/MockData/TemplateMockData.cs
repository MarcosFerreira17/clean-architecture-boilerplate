using System.Linq;
using Template.Domain.Dtos;
using Template.Domain.Entities;

namespace Template.Tests.Helpers.MockData;

public static class TemplateMockData
{
    public static List<TemplateEntity> GetAllTemplate()
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

    public static List<TemplateEntity> GetEmptyListTemplate()
    {
        return new List<TemplateEntity>();
    }
    public static List<TemplateDto> GetAllTemplateDto()
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

    public static TemplateDto NewTemplateDto()
    {
        return new TemplateDto
        {
            Id = 1,
            ExampleString = "We create a new entity mockdb"
        };
    }

    public static TemplateEntity NewTemplate()
    {
        return new TemplateEntity
        {
            Id = 1,
            ExampleString = "We create a new entity mockdb"
        };
    }
}