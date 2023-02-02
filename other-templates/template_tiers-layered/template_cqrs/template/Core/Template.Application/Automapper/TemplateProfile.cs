using Template.Application.Features.Commands.CreateTemplate;
using Template.Application.Features.Commands.UpdateTemplate;
using Template.Application.Features.Queries.GetTemplateList;
using AutoMapper;
using Template.Domain.Entities;
using Template.Application.Features.Queries.GetTemplateById;

namespace Template.Application.Automapper;

public class TemplateProfile : Profile
{
    public TemplateProfile()
    {
        CreateMap<CreateTemplateCommand, Entity>().ReverseMap();
        CreateMap<UpdateTemplateCommand, Entity>().ReverseMap();
        CreateMap<EntityDto, Entity>().ReverseMap();
        CreateMap<TemplateReponse, Entity>().ReverseMap();
    }
}