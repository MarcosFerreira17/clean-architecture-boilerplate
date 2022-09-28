using Domain.Entities;

namespace Application.Interfaces;
public interface ITemplateRepository<Tid> : IBaseRepository<Entity>
{
    public Task<Entity> GetByIdAsync(Tid id);
}