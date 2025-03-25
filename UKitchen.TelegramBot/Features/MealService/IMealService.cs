using UKitchen.Domain.Data.Dto.Telegram;
using UniversityKitchen.Data.Models;

namespace UKitchen.TelegramBot.Features.MealService;

public interface IMealService
{
    Task<List<GetMealForTelegram>> GetAll();
}