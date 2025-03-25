using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Update;
using UKitchen.Domain.Data.Dto.ExcelDto;
using UKitchen.Domain.Data.Dto.MealDto;
using UniversityKitchen.Data.Context;
using UniversityKitchen.Data.Models;
using UniversityKitchen.Exception;
using UniversityKitchen.Features.ImportFile;
using UniversityKitchen.Features.Meal.Dto;

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
            var mappedMeal = mapper.Map<Data.Models.Meal>(dto);
            await context.AddAsync(mappedMeal);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UploadMealFile(IFormFile file)
        {
            var result = await excel.ReadExcelFileAsync(file);
            var mappedResult = mapper.Map<List<Data.Models.Meal>>(result);
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
