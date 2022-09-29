using AutoMapper;
using Template.Domain.Dtos;
using Template.Domain.Entities;

namespace Template.Infrastructure.Automapper;

public class TemplateProfile : Profile
{
    public TemplateProfile()
    {
        CreateMap<TemplateDto, TemplateEntity>().ReverseMap();
    }
}