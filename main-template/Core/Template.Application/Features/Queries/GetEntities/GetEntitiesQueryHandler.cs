using Template.Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Template.Application.Features.Queries.GetEntities;

public class GetEntityListQueryHandler : IRequestHandler<GetEntitiesQuery, List<GetEntitiesViewModel>>
{
    private readonly ITemplateRepository<long> _repository;
    private readonly IMapper _mapper;

    public GetEntityListQueryHandler(ITemplateRepository<long> repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<List<GetEntitiesViewModel>> Handle(GetEntitiesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync();

        return await Task.FromResult(_mapper.Map<List<GetEntitiesViewModel>>(entities));
    }
}
