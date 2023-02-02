using AutoMapper;
using Costumer.Domain.Dtos;
using Costumer.Domain.Entities;

namespace Costumer.Infraestructure.Automapper;

public class CostumerProfile : Profile
{
    public CostumerProfile()
    {
        CreateMap<PersonDto, Person>().ReverseMap();
        CreateMap<ListPersonDto, Person>().ReverseMap();
    }
}