using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UKitchen.Domain.Data.Dto.MealDto;
using UniversityKitchen.Data.Context;
using UniversityKitchen.Features.ImportFile;

namespace UniversityKitchen.Features.Meal
{
    public class MealService(AppDbContext context, IMapper mapper, IExcelService excel) : IMealService
    {
        public async Task<List<GetMealDto>> GetAll()
        {
            var meals = await context.Meals.ToListAsync();
            return mapper.Map<List<GetMealDto>>(meals);
        }

        public Task<GetMealDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Create(CreateMealDto dto)
        {
            var mappedMeal = mapper.Map<UKitchen.Domain.Data.Models.Meal>(dto);
            await context.AddAsync(mappedMeal);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UploadMealFile(IFormFile file)
        {
            var result = await excel.ReadExcelFileAsync(file);
            var mappedResult = mapper.Map<List<UKitchen.Domain.Data.Models.Meal>>(result);
            await context.AddRangeAsync(mappedResult);
            await context.SaveChangesAsync();
            return true;
        }

        public Task<bool> Update()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
