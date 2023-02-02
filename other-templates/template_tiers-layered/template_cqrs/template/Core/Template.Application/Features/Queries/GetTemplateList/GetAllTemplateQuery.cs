using MediatR;

namespace Template.Application.Features.Queries.GetTemplateList
{
    public class GetAllTemplateQuery : IRequest<IEnumerable<EntityDto>>
    {
    }
}