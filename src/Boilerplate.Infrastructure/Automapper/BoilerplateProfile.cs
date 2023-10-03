using AutoMapper;
using Boilerplate.Domain.Dtos;
using Boilerplate.Domain.Entities;

namespace Boilerplate.Infrastructure.Automapper;

public class BoilerplateProfile : Profile
{
    public BoilerplateProfile()
    {
        CreateMap<BoilerplateDto, BoilerplateEntity>().ReverseMap();
    }
}