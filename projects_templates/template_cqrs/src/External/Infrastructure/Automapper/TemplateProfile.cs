using AutoMapper;
using Domain.Dto;
using Domain.Entities;

namespace Infrastructure.Automapper;

public class TemplateProfile : Profile
{
    public TemplateProfile()
    {
        CreateMap<EntityDto, Entity>().ReverseMap();
    }
}