using Template.Domain.Entities;

namespace Template.Application.Interfaces;
public interface ITemplateRepository<Tid> : IBaseRepository<Entity>
{
    Task<Entity> GetByIdAsync(Tid id);
}