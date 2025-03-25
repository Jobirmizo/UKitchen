using Microsoft.EntityFrameworkCore;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;

namespace UKitchen.TelegramBot.Services;

public class BotBackgroundService : BackgroundService
{
    private readonly TelegramBotClient _client;
    private readonly ILogger<BotBackgroundService> _logger;
    private readonly IUpdateHandler _handler;

    public BotBackgroundService(
        ILogger<BotBackgroundService> logger,
        TelegramBotClient client,
        IUpdateHandler handler)
    {
        _client = client;
        _handler = handler;
        _logger = logger;
    }
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var bot = await _client.GetMeAsync(stoppingToken);
        _logger.LogInformation("Bot Started Successfully: {me.Username}", bot.Username);
        
        _client.StartReceiving(
            _handler.HandleUpdateAsync,
            _handler.HandleErrorAsync,
            new ReceiverOptions
            {
                AllowedUpdates = Array.Empty<UpdateType>(),
            },
            stoppingToken
        );
    }
}