using System.Linq;
using Template.Application.Common;
using Template.Application.Interfaces;
using Template.Application.RequestFeatures;
using AutoMapper;
using Template.Domain.Entities;
using MediatR;

namespace Template.Application.Features.Queries.GetTemplateList;

public class GetTemplateListQueryHandler : IRequestHandler<GetTemplateParameters, PagedList<EntityDto>>
{
    private readonly ITemplateRepository<long> _repository;
    private readonly IMapper _mapper;

    public GetTemplateListQueryHandler(ITemplateRepository<long> repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<PagedList<EntityDto>> Handle(GetTemplateParameters request, CancellationToken cancellationToken)
    {
        var entities = _repository.FindByCondition(x => x.Id >= 1)
                                    .FilterTemplate(request.MinId, request.MaxId)
                                    .Search(request.SearchTerm)
                                    .OrderBy(t => t.Id)
                                    // .Sort(templateParameters.OrderBy)
                                    .ToList();

        var mappedEntity = _mapper.Map<List<EntityDto>>(entities);

        return PagedList<EntityDto>.ToPagedList(mappedEntity, request.PageNumber, request.PageSize);
    }
}
