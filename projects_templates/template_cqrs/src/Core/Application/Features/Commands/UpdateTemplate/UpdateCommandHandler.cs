using Application.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.Commands.UpdateTemplate;

public class UpdateCommandHandler : IRequestHandler<UpdateTemplateCommand>
{
    private readonly ITemplateRepository<long> _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<UpdateCommandHandler> _logger;

    public UpdateCommandHandler(ITemplateRepository<long> repository, IMapper mapper, ILogger<UpdateCommandHandler> logger)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<Unit> Handle(UpdateTemplateCommand request, CancellationToken cancellationToken)
    {
        var templateToUpdate = await _repository.GetByIdAsync(request.Id);
        if (templateToUpdate == null)
        {
            throw new NotFoundException(nameof(Entity), request.Id);
        }

        _mapper.Map(request, templateToUpdate, typeof(UpdateTemplateCommand), typeof(Entity));
        await _repository.UpdateAsync(templateToUpdate);

        _logger.LogInformation($"Entity {templateToUpdate.Id} is successfully updated.");

        return Unit.Value;
    }
}
