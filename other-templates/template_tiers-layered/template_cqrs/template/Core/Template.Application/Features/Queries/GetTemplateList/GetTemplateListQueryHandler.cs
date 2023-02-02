using Template.Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Template.Application.Features.Queries.GetTemplateList;

public class GetTemplateListQueryHandler : IRequestHandler<GetAllTemplateQuery, IEnumerable<EntityDto>>
{
    private readonly ITemplateRepository<long> _repository;
    private readonly IMapper _mapper;

    public GetTemplateListQueryHandler(ITemplateRepository<long> repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<IEnumerable<EntityDto>> Handle(GetAllTemplateQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync();

        return _mapper.Map<List<EntityDto>>(entities);
    }
}
