using Application.Features.Commands.CreateTemplate;
using Application.Features.Commands.UpdateTemplate;
using AutoMapper;
using Domain.Entities;

namespace Application.Automapper;

public class TemplateProfile : Profile
{
    public TemplateProfile()
    {
        CreateMap<CreateTemplateCommand, Entity>().ReverseMap();
        CreateMap<UpdateTemplateCommand, Entity>().ReverseMap();
    }
}