using MediatR;

namespace Template.Application.Features.Queries.GetEntities;

public class GetEntitiesQuery : IRequest<List<GetEntitiesViewModel>>
{
}