using AutoMapper;
using UniversityKitchen.Data.Enum;
using UniversityKitchen.Data.Models;
using UniversityKitchen.Features.Auth.Dtos;

namespace UniversityKitchen.Features;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<RegisterDto, User>()
            .ForMember(dest => dest.RoleEnum, opt => opt.MapFrom(src => (RoleEnum)src.SelectedRole))
            .ReverseMap();
    }
}