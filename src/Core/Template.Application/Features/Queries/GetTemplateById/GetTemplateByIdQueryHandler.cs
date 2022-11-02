using Template.Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Template.Application.Features.Queries.GetTemplateById;

public class GetTemplateByIdQueryHandler : IRequestHandler<GetTemplateByIdQuery, GetParameterId>
{
    private readonly ITemplateRepository<long> _repository;
    private readonly IMapper _mapper;

    public GetTemplateByIdQueryHandler(ITemplateRepository<long> repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<GetParameterId> Handle(GetTemplateByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id);

        return _mapper.Map<GetParameterId>(entity);
    }
}
