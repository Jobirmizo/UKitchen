using UKitchen.Domain.Data.Dto.CompanyDto;

namespace UniversityKitchen.Features.Company;

public interface ICompanyService
{
    Task<List<GetCompany>> GetAll();
}