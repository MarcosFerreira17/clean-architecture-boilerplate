using MediatR;

namespace Template.Application.Features.Queries.GetTemplateById;

public class GetTemplateByIdQuery : IRequest<TemplateReponse>
{
    public GetTemplateByIdQuery(long id)
    {
        Id = id;
    }
    public long Id { get; set; }
}
