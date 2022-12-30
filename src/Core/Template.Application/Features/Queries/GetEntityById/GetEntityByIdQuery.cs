using MediatR;

namespace Template.Application.Features.Queries.GetEntityById;

public class GetEntityByIdQuery : IRequest<GetParameterId>
{
    public GetEntityByIdQuery(long id)
    {
        Id = id;
    }

    public long Id { get; set; }
}
