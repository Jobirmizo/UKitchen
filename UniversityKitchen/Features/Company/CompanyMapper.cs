using AutoMapper;
using UKitchen.Domain.Data.Dto.CompanyDto;

namespace UniversityKitchen.Features.Company;

public class CompanyMapper : Profile
{
    public CompanyMapper()
    {
        CreateMap<UKitchen.Domain.Data.Models.Company, GetCompany>();
    }
        
}