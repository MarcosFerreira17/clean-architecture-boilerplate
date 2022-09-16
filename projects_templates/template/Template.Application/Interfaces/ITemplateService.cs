using Template.Application.RequestFeatures;
using Template.Domain.Common;
using Template.Domain.Dtos;

namespace Template.Domain.Interfaces;

public interface ITemplateService : IBaseService<TemplateDto, long>
{
    Task<PagedList<TemplateDto>> PagedGetAll(TemplateParameters TemplateParameters);
}
