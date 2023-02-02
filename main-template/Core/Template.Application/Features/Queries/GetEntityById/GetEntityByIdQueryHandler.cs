using Template.Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Template.Application.Features.Queries.GetEntityById;

public class GetEntityByIdQueryHandler : IRequestHandler<GetEntityByIdQuery, GetParameterId>
{
    private readonly ITemplateRepository<long> _repository;
    private readonly IMapper _mapper;

    public GetEntityByIdQueryHandler(ITemplateRepository<long> repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<GetParameterId> Handle(GetEntityByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id);

        return await Task.FromResult(_mapper.Map<GetParameterId>(entity));
    }
}
