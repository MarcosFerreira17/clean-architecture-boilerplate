using AutoMapper;
using Template.Domain.Dtos;
using Template.Domain.Entities;

namespace Template.Infraestructure.Automapper;

public class TemplateProfile : Profile
{
    public TemplateProfile()
    {
        CreateMap<TemplateDto, TemplateEntity>().ReverseMap();
    }
}