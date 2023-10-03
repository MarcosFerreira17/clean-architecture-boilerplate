using AutoMapper;
using Boilerplate.Domain.Dtos;
using Boilerplate.Domain.Entities;

namespace Boilerplate.Infra.Database.Automapper;

public class BoilerplateProfile : Profile
{
    public BoilerplateProfile()
    {
        CreateMap<BoilerplateDto, BoilerplateEntity>().ReverseMap();
    }
}