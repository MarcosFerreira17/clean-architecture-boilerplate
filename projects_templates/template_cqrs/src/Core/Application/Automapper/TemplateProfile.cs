using Application.Features.Commands.CreateTemplate;
using Application.Features.Commands.UpdateTemplate;
using Application.Features.Queries.GetTemplateList;
using AutoMapper;
using Domain.Entities;

namespace Application.Automapper;

public class TemplateProfile : Profile
{
    public TemplateProfile()
    {
        CreateMap<CreateTemplateCommand, Entity>().ReverseMap();
        CreateMap<UpdateTemplateCommand, Entity>().ReverseMap();
        CreateMap<EntityDto, Entity>().ReverseMap();
    }
}