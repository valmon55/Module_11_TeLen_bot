using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace CS_Basic.TeLen_bot.Controllers
{
    public class TextMessageController
    {
        private readonly ITelegramBotClient _telegramClient;
        public TextMessageController(ITelegramBotClient telegramClient)
        {
            _telegramClient= telegramClient;
        }
        public async Task Handle(Message message, CancellationToken ct)
        {
            //Console.WriteLine($"Контроллер {GetType().Name} получил сообщение");
            //await _telegramClient.SendTextMessageAsync(message.Chat.Id, $"Получено текстовое сообщение", cancellationToken: ct);
            switch (message.Text)
            {
                case "/start":
                    var buttons = new List<InlineKeyboardButton[]>();
                    buttons.Add(new[]
                    {
                            InlineKeyboardButton.WithCallbackData($"Длина", $"len"),
                            InlineKeyboardButton.WithCallbackData($"Сумма", $"sum")
                        }); ;
                    await _telegramClient.SendTextMessageAsync(message.Chat.Id, 
                        $"<b>Наш бот считает длину строки</b> {Environment.NewLine}" +
                        $"или {Environment.NewLine} " +
                        $"<b>Суммирует числа</b> {Environment.NewLine}"
                        , cancellationToken: ct
                        , parseMode: ParseMode.Html
                        , replyMarkup: new InlineKeyboardMarkup(buttons));
                        break;
                default: 
                    break;
            }
        }
    }
}
