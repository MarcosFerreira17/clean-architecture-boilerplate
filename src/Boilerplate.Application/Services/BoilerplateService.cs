using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Boilerplate.Application.Exceptions;
using Boilerplate.Application.Services.Interfaces;
using Boilerplate.Application.RequestFeatures;
using Boilerplate.Domain.Dtos;
using Boilerplate.Domain.Entities;
using Boilerplate.Infra.Database.Repositories.Interfaces;
using Boilerplate.Infra.Database.Repositories;

namespace Boilerplate.Application.Services;

public class BoilerplateService : IBoilerplateService
{
    protected readonly IBoilerplateRepository _repo;
    protected readonly IMapper _mapper;
    protected readonly ILogger<BoilerplateService> _logger;
    public BoilerplateService(IBoilerplateRepository repo, IMapper mapper, ILogger<BoilerplateService> logger)
    {
        _repo = repo;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task Create(BoilerplateDto BoilerplateDto)
    {
        var entityfromdb = _mapper.Map<BoilerplateEntity>(BoilerplateDto);
        await _repo.Create(entityfromdb);
    }

    public async Task Update(long id, BoilerplateDto BoilerplateDto)
    {
        await SearchForExistingId(id);
        if (id != BoilerplateDto.Id)
        {
            _logger.LogError("Parameter and request id must match");
            throw new NotFoundException("Parameter and request id must match.");
        }
        var updateEntity = _mapper.Map<BoilerplateEntity>(BoilerplateDto);
        await _repo.Update(updateEntity);
    }

    public async Task Delete(long id)
    {
        var entity = await SearchForExistingId(id);
        await _repo.Delete(entity);
    }

    public async Task<PagedList<BoilerplateDto>> PagedGetAll(BoilerplateParameters BoilerplateParameters)
    {
        if (!BoilerplateParameters.ValidIdRange) throw new BadRequestException("MinId cannot be greater than MaxId");

        var entities = await _repo.FindByCondition(x => x.Id >= 1)
                            .FilterBoilerplate(BoilerplateParameters.MinId, BoilerplateParameters.MaxId)
                            .Search(BoilerplateParameters.SearchTerm)
                            .OrderBy(t => t.Id)
                            .ToListAsync();

        var pagedEntities = _mapper.Map<List<BoilerplateDto>>(entities);
        return PagedList<BoilerplateDto>.ToPagedList(pagedEntities, BoilerplateParameters.PageNumber, BoilerplateParameters.PageSize);
    }

    public async Task<IEnumerable<BoilerplateDto>> GetAll()
    {
        var entities = await _repo.FindAll();
        var mappedEntity = _mapper.Map<IEnumerable<BoilerplateDto>>(entities);
        if (entities == null)
        {
            _logger.LogInformation("No data found");
            throw new NotFoundException("No data found.");
        }
        return mappedEntity;
    }

    public async Task<BoilerplateDto> GetById(long id)
    {
        var entityFromDb = await SearchForExistingId(id);

        return _mapper.Map<BoilerplateDto>(entityFromDb);
    }

    protected async Task<BoilerplateEntity> SearchForExistingId(long id)
    {
        if (id < 1)
        {
            _logger.LogError("Field id must be filled");
            throw new NotFoundException("Field id must be filled and has to be greater than 0.");
        }

        var entityFromDb = await _repo.FindByCondition(x => x.Id == id).FirstOrDefaultAsync();
        if (entityFromDb is not null) return _mapper.Map<BoilerplateEntity>(entityFromDb);
        _logger.LogInformation("Id not found");
        throw new NotFoundException("This id does not exist in our database, please check and try again.");

    }
}