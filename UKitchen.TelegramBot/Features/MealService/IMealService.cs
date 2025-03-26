using UKitchen.Domain.Data.Dto.Telegram;

namespace UKitchen.TelegramBot.Features.MealService;

public interface IMealService
{
    Task<List<GetMealForTelegram>> GetAll();
}