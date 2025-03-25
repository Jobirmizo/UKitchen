using AutoMapper;
using UKitchen.Domain.Data.Dto.ExcelDto;
using UKitchen.Domain.Data.Dto.MealDto;
using UniversityKitchen.Data.Models;
using UniversityKitchen.Features.Meal.Dto;

namespace UniversityKitchen.Features.Meal
{
    public class MealMapper : Profile
    {
        public MealMapper()
        {
            CreateMap<CreateMealDto, Data.Models.Meal>().ReverseMap();
            CreateMap<Data.Models.Meal, GetMealDto>();
            CreateMap<MealExcelDto, Data.Models.Meal>();
        }
    }
}

