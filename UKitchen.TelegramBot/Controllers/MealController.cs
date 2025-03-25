using System.Text.Json.Serialization.Metadata;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using UKitchen.TelegramBot.Features.MealService;

namespace UKitchen.TelegramBot.Controllers;

[ApiController]
[Route("api/telegram")]
public class MealController : ControllerBase
{
    private readonly TelegramBotClient _botClient;
    private readonly IMealService _meal;

    public MealController(IConfiguration configuration, IMealService meal, TelegramBotClient botClient)
    {
        string botToken = configuration["TelegramBot:Token"] = null!;
        _botClient = botClient;
        _meal = meal;
    }

}