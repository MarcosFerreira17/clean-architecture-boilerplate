using Template.Application.RequestFeatures;
using Template.Domain.Dtos;

namespace Template.Application.Interfaces;

public interface ITemplateService : IBaseService<TemplateDto, long>
{
    Task<PagedList<TemplateDto>> PagedGetAll(TemplateParameters TemplateParameters);
}
