using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Template.Application.Exceptions;
using Template.Application.Interfaces;
using Template.Application.RequestFeatures;
using Template.Domain.Dtos;
using Template.Domain.Entities;
using Template.Infrastructure.Interfaces;
using Template.Infrastructure.Repositories;

namespace Template.Application.Services;

public class TemplateService : ITemplateService
{
    protected readonly ITemplateRepository _repo;
    protected readonly IMapper _mapper;
    protected readonly ILogger<TemplateService> _logger;
    // protected readonly IValidator<TemplateEntity> _validator;
    public TemplateService(ITemplateRepository repo, IMapper mapper, ILogger<TemplateService> logger)
    {
        _repo = repo;
        // _validator = validator;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task Create(TemplateDto templateDto)
    {
        var entityfromdb = _mapper.Map<TemplateEntity>(templateDto);
        // var validation = await _validator.ValidateAsync(entityfromdb);

        // if (!validation.IsValid)
        // {
        //     _logger.LogError("Incorret format validation.");
        //     throw new GenericException();
        // }
        await _repo.Create(entityfromdb);
    }

    public async Task Update(long id, TemplateDto templateDto)
    {
        await SearchForExistingId(id);
        if (id != templateDto.Id)
        {
            _logger.LogError("Parameter and request id must match");
            throw new NotFoundException("Parameter and request id must match.");
        }
        var updateEntity = _mapper.Map<TemplateEntity>(templateDto);
        await _repo.Update(updateEntity);
    }

    public async Task Delete(long id)
    {
        var entity = await SearchForExistingId(id);
        await _repo.Delete(entity);
    }

    public async Task<PagedList<TemplateDto>> PagedGetAll(TemplateParameters templateParameters)
    {
        if (!templateParameters.ValidIdRange) throw new BadRequestException("MinId cannot be greater than MaxId");

        var entities = await _repo.FindByCondition(x => x.Id >= 1)
                            .FilterTemplate(templateParameters.MinId, templateParameters.MaxId)
                            .Search(templateParameters.SearchTerm)
                            .OrderBy(t => t.Id)
                            // .Sort(templateParameters.OrderBy)
                            .ToListAsync();

        var pagedEntities = _mapper.Map<List<TemplateDto>>(entities);
        return PagedList<TemplateDto>.ToPagedList(pagedEntities, templateParameters.PageNumber, templateParameters.PageSize);
    }

    public async Task<IEnumerable<TemplateDto>> GetAll()
    {
        var entities = await _repo.FindAll();
        var mappedEntity = _mapper.Map<IEnumerable<TemplateDto>>(entities);
        if (entities == null)
        {
            _logger.LogInformation("No data found");
            throw new NotFoundException("No data found.");
        }
        return mappedEntity;
    }

    public async Task<TemplateDto> GetById(long id)
    {
        var entityFromDb = await SearchForExistingId(id);

        return _mapper.Map<TemplateDto>(entityFromDb);
    }

    protected async Task<TemplateEntity> SearchForExistingId(long id)
    {
        if (id < 1)
        {
            _logger.LogError("Field id must be filled");
            throw new NotFoundException("Field id must be filled and has to be greater than 0.");
        }

        var entityFromDb = await _repo.FindByCondition(x => x.Id == id).FirstOrDefaultAsync();
        if (entityFromDb is not null) return _mapper.Map<TemplateEntity>(entityFromDb);
        _logger.LogInformation("Id not found");
        throw new NotFoundException("This id does not exist in our database, please check and try again.");
    }
}