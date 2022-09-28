using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.Commands.CreateTemplate;

public class CreateCommandHandler : IRequestHandler<CreateTemplateCommand, long>
{
    private readonly ITemplateRepository<long> _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateCommandHandler> _logger;

    public CreateCommandHandler(ITemplateRepository<long> repository, IMapper mapper, ILogger<CreateCommandHandler> logger)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<long> Handle(CreateTemplateCommand request, CancellationToken cancellationToken)
    {
        var templateEntity = _mapper.Map<Entity>(request);
        var newEntity = await _repository.AddAsync(templateEntity);

        _logger.LogInformation($"Entity {newEntity.Id} is successfully created.");

        return newEntity.Id;
    }
}
