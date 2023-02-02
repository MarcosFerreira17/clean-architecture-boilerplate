using MediatR;

namespace Template.Application.Features.Queries.GetTemplateList;

public record class EntityDto
{
    public long Id { get; set; }
    public string Example { get; set; }
}
