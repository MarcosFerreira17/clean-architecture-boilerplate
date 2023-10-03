using Boilerplate.Application.RequestFeatures;
using Boilerplate.Domain.Dtos;

namespace Boilerplate.Application.Services.Interfaces;

public interface IBoilerplateService : IBaseService<BoilerplateDto, long>
{
    Task<PagedList<BoilerplateDto>> PagedGetAll(BoilerplateParameters BoilerplateParameters);
}
