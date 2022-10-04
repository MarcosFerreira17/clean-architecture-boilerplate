using Application.RequestFeatures;
using MediatR;

namespace Application.Features.Queries.GetTemplateById;

public class GetTemplateByIdQuery : IRequest<GetParameterId>
{
    public long Id { get; set; }
}
