using AutoMapper;
using UKitchen.Domain.Data.Dto.AuthDto;
using UKitchen.Domain.Data.Models;

namespace UniversityKitchen.Features.Auth;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<RegisterDto, User>()
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.CountryCode + src.PhoneNumber))
            .ReverseMap();
    }
}