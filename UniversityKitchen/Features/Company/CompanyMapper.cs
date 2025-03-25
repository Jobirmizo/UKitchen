using AutoMapper;

namespace UniversityKitchen.Features.Company;

public class CompanyMapper : Profile
{
    public CompanyMapper()
    {
        CreateMap<Data.Models.Company, GetCompany>();
    }
        
}