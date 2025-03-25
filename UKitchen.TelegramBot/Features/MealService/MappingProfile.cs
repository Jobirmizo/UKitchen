using AutoMapper;
using UKitchen.Domain.Data.Dto.Telegram;
using UniversityKitchen.Data.Models;

namespace UKitchen.TelegramBot.Features.MealService;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<GetMealForTelegram, Meal>().ReverseMap();
    }
}