using System.Globalization;
using Microsoft.Extensions.Localization;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using UKitchen.TelegramBot.Resources;

namespace UKitchen.TelegramBot.Services;

public partial class BotUpdateHandler : IUpdateHandler
{
    private readonly ILogger<BotUpdateHandler> _logger;
    private readonly IServiceScopeFactory _scopeFactory;
    private IStringLocalizer _localizer;
    public BotUpdateHandler(ILogger<BotUpdateHandler> logger
    ,IServiceScopeFactory scopeFactory)
    {
        _logger = logger;
        _scopeFactory = scopeFactory;
    }
    public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        var culture = new CultureInfo("en-US");
        CultureInfo.CurrentCulture = culture;
        CultureInfo.CurrentUICulture = culture;
        using var scope = _scopeFactory.CreateScope();
        _localizer = scope.ServiceProvider.GetRequiredService<IStringLocalizer<BotLocalizer>>();
        var handler = update.Type switch
        {
            UpdateType.Message => HandleMessageAsync(botClient, update.Message, cancellationToken),
            UpdateType.EditedMessage => HandleEditMessageAsync(botClient, update.EditedMessage, cancellationToken),
            //handle other updates here man
            _ => HandleUnknownUpdate(botClient, update, cancellationToken)
        };

        try
        {
            await handler;
        }
        catch (Exception e)
        {
            await HandlePollingErrorAsync(botClient, e, cancellationToken);
        }
    }

    public Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, HandleErrorSource source,
        CancellationToken cancellationToken)
    {
        _logger.LogError(exception, "An error occurred in {Source}: {Message}", source, exception.Message);
        return Task.CompletedTask;
    }

    public Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        _logger.LogError(exception, "Polling error occurred: {Message}", exception.Message);
        return Task.CompletedTask;
    }

    private Task HandleUnknownUpdate(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        var from = update.Message?.From;
        _logger.LogInformation("Update type {update.Type} recieved", update.Type);
        return Task.CompletedTask;
    }
}
