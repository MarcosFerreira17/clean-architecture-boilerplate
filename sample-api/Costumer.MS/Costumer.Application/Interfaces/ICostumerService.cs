using Costumer.Application.RequestFeatures;
using Costumer.Domain.Common;
using Costumer.Domain.Dtos;

namespace Costumer.Domain.Interfaces;

public interface ICostumerService : IBaseService<PersonDto, long>
{
    Task<PagedList<PersonDto>> PagedGetAll(CostumerParameters CostumerParameters);
}
