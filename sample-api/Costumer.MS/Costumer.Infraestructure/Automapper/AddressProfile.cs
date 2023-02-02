using AutoMapper;
using Costumer.Domain.Dtos;
using Costumer.Domain.ValueObjects;

namespace Costumer.Infraestructure.Automapper;

public class AddressProfile : Profile
{
    public AddressProfile()
    {
        CreateMap<AddressDto, Address>().ReverseMap();
    }
}