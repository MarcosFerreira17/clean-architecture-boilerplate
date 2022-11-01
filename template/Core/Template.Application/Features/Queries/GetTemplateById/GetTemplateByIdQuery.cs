using Template.Application.RequestFeatures;
using MediatR;

namespace Template.Application.Features.Queries.GetTemplateById;

public class GetTemplateByIdQuery : IRequest<GetParameterId>
{
    public long Id { get; set; }
}
