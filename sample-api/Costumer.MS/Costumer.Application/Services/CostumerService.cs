using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Costumer.Application.Exceptions;
using Costumer.Application.RequestFeatures;
using Costumer.Domain.Dtos;
using Costumer.Domain.Entities;
using Costumer.Domain.Interfaces;
using Costumer.Infraestructure.Repositories;

namespace Costumer.Domain.Services;

public class CostumerService : ICostumerService
{
    protected readonly ICostumerRepository _repo;
    protected readonly IMapper _mapper;
    protected readonly ILogger<CostumerService> _logger;
    public CostumerService(ICostumerRepository repo, IMapper mapper, ILogger<CostumerService> logger)
    {
        _repo = repo;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task Create(PersonDto costumerDto)
    {
        var entityfromdb = _mapper.Map<Person>(costumerDto);
        await _repo.Create(entityfromdb);
    }

    public async Task Update(long id, PersonDto costumerDto)
    {
        await SearchForExistingId(id);
        if (id != costumerDto.Id)
        {
            _logger.LogError("Parameter and request id must match");
            throw new NotFoundException("Parameter and request id must match.");
        }
        var updateEntity = _mapper.Map<Person>(costumerDto);
        await _repo.Update(updateEntity);
    }

    public async Task Delete(long id)
    {
        var entity = await SearchForExistingId(id);
        await _repo.Delete(entity);
    }

    public async Task<PagedList<PersonDto>> PagedGetAll(CostumerParameters CostumerParameters)
    {
        if (!CostumerParameters.ValidIdRange) throw new BadRequestException("MinId cannot be greater than MaxId");

        var entities = await _repo.FindByCondition(x => x.Id >= 0)
                            .FilterCostumer(CostumerParameters.MinId, CostumerParameters.MaxId)
                            .Search(CostumerParameters.SearchTerm)
                            .OrderBy(t => t.Id)
                            .ToListAsync();

        var pagedEntities = _mapper.Map<List<PersonDto>>(entities);
        return PagedList<PersonDto>.ToPagedList(pagedEntities, CostumerParameters.PageNumber, CostumerParameters.PageSize);
    }

    public async Task<IEnumerable<PersonDto>> GetAll()
    {
        var entities = await _repo.FindAll();
        var mappedEntity = _mapper.Map<IEnumerable<PersonDto>>(entities);
        if (entities == null)
        {
            _logger.LogInformation("No data found.");
            throw new NotFoundException("No data found.");
        }
        return mappedEntity;
    }

    public async Task<PersonDto> GetById(long id)
    {
        var entityFromDb = await SearchForExistingId(id);

        return _mapper.Map<PersonDto>(entityFromDb);
    }

    protected async Task<Person> SearchForExistingId(long id)
    {
        if (id < 1)
        {
            _logger.LogError("Field id must be filled.");
            throw new NotFoundException("Field id must be filled and has to be greater than 0.");
        }

        var entityFromDb = await _repo.FindByCondition(x => x.Id == id).FirstOrDefaultAsync();
        if (entityFromDb is null)
        {
            _logger.LogInformation("Id not found");
            throw new NotFoundException("This id does not exist in our database, please check and try again.");
        }

        return _mapper.Map<Person>(entityFromDb);
    }
}