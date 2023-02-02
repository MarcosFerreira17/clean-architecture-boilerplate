using AutoMapper;
using Template.Domain.Entities;
using Template.Application.Features.Commands.CreateTemplate;
using Template.Application.Features.Commands.UpdateTemplate;
using Template.Application.Features.Queries.GetEntityById;
using Template.Application.Features.Queries.GetEntities;

namespace Template.Application.Automapper;

public class TemplateProfile : Profile
{
    public TemplateProfile()
    {
        CreateMap<CreateTemplateCommand, Entity>().ReverseMap();
        CreateMap<UpdateTemplateCommand, Entity>().ReverseMap();
        CreateMap<GetParameterId, Entity>().ReverseMap();
        CreateMap<GetEntitiesViewModel, Entity>().ReverseMap();
    }
}