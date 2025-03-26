using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using UKitchen.Domain.Data.Dto.CompanyDto;
using UniversityKitchen.Data.Context;

namespace UniversityKitchen.Features.Company;

public class CompanyService(AppDbContext context, IMapper mapper) : ICompanyService
{
    public async Task<List<GetCompany>> GetAll()
    {
        return await context.Companies
            .ProjectTo<GetCompany>(mapper.ConfigurationProvider)
            .ToListAsync();
    }
}