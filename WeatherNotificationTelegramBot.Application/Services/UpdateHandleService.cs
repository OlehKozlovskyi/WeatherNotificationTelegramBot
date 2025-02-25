using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.ReplyMarkups;
using WeatherNotificationTelegramBot.Application.Abstractions;

namespace WeatherNotificationTelegramBot.Application.Services
{
    public class UpdateHandleService(ITelegramBotClient client, ILogger<UpdateHandleService> logger, IOpenWeatherService weatherService)
    {
        public async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, HandleErrorSource source, CancellationToken cancellationToken)
        {
            logger.LogInformation("Occur Error: {Exception}", exception);
            if (exception is RequestException)
                await Task.Delay(TimeSpan.FromSeconds(2), cancellationToken);
        }

        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await (update switch
            {
                { Message: { } message } => OnMessage(message),
                { EditedMessage: { } message } => OnMessage(message),
                { CallbackQuery: { } callbackQuery } => OnCallbackQuery(callbackQuery),
                _ => UnknownUpdateHandlerAsync(update)
            });
        }

        private async Task OnCallbackQuery(CallbackQuery callbackQuery)
        {
            if (callbackQuery == null)
                return;
            switch (callbackQuery.Data)
            {
                case "location":
                    await client.SendMessage(callbackQuery.Message.Chat.Id, "Enter name of village/city:");
                    break;
            }
        }

        private async Task GetWeatherAsync(Message msg)
        {
            await weatherService.GetWeatherAsync(msg.Text);
            //await client.SendMessage(msg.Chat.Id, $"В {msg.Text} +20 нахуй:");
        }

        private async Task OnMessage(Message msg)
        {
            logger.LogInformation("Receive message type: {MessageType}", msg.Type);
            if (msg.Text == null)
                return;
            if(msg.Text == "/start")
            {
                var inlineKeyboard = new InlineKeyboardMarkup(
                new InlineKeyboardButton[][]
                {
                    new InlineKeyboardButton[]
                    {
                        InlineKeyboardButton.WithCallbackData("/weather", "location")
                    }
                });
                await client.SendMessage(msg.Chat.Id, ".", replyMarkup: inlineKeyboard);
            }
            else
            {
                await GetWeatherAsync(msg);
            }
            
            logger.LogInformation("The message was sent with id: {SentMessageId}", msg.Id);
        }

        private Task UnknownUpdateHandlerAsync(Update update)
        {
            logger.LogInformation("Unknown update type: {UpdateType}", update.Type);
            return Task.CompletedTask;
        }
    }
}
