using AutoMapper;
using UKitchen.Domain.Data.Dto.ExcelDto;
using UKitchen.Domain.Data.Dto.MealDto;

namespace UniversityKitchen.Features.Meal
{
    public class MealMapper : Profile
    {
        public MealMapper()
        {
            CreateMap<CreateMealDto, UKitchen.Domain.Data.Models.Meal>().ReverseMap();
            CreateMap<UKitchen.Domain.Data.Models.Meal, GetMealDto>();
            CreateMap<MealExcelDto, UKitchen.Domain.Data.Models.Meal>();
        }
    }
}

