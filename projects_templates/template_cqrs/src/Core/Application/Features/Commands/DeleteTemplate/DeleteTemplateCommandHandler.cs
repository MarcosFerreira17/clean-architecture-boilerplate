using Application.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.Commands.DeleteTemplate;

public class DeleteTemplateCommandHandler : IRequestHandler<DeleteTemplateCommand>
{
    private readonly ITemplateRepository<long> _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<DeleteTemplateCommandHandler> _logger;

    public DeleteTemplateCommandHandler(ITemplateRepository<long> repository, IMapper mapper, ILogger<DeleteTemplateCommandHandler> logger)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<Unit> Handle(DeleteTemplateCommand request, CancellationToken cancellationToken)
    {
        var templateToDelete = await _repository.GetByIdAsync(request.Id);
        if (templateToDelete == null)
        {
            throw new NotFoundException(nameof(Entity), request.Id);
        }

        await _repository.DeleteAsync(templateToDelete);

        _logger.LogInformation($"Entity {templateToDelete.Id} is successfully deleted.");

        return Unit.Value;
    }
}
