using Domain.Entities;

namespace Application.Interfaces;
public interface ITemplateRepository<Tid> : IBaseRepository<Entity>
{
    Task<Entity> GetByIdAsync(Tid id);
}