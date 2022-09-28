using Application.RequestFeatures;
using MediatR;

namespace Application.Features.Queries.GetTemplateList;

public class GetTemplateParameters : RequestParameters, IRequest<PagedList<EntityDto>>
{
    public GetTemplateParameters()
    {
        OrderBy = "desc";
    }
    public uint MinId { get; set; }
    public uint MaxId { get; set; } = int.MaxValue;
    public string SearchTerm { get; set; }
}
