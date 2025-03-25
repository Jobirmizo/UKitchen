using Telegram.Bot;
using Telegram.Bot.Types;

namespace UKitchen.TelegramBot.Services;

public partial class BotUpdateHandler
{
    private async Task HandleEditMessageAsync(ITelegramBotClient client, Message? message,
        CancellationToken token)
    {
        ArgumentNullException.ThrowIfNull(message);
        var from = message.From;
        _logger.LogInformation("Recieved edit message from {from.username}: {message.Text}", from?.FirstName, message.Text);
    }
}