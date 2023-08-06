using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace CS_Basic.TeLen_bot.Controllers
{
    public class DefaultMessageController
    {
        private readonly ITelegramBotClient _telegramClient;
        public DefaultMessageController(ITelegramBotClient telegramClient)
        {
            _telegramClient = telegramClient;
        }
        public async Task Handle(Message message, CancellationToken ct)
        {
            Console.WriteLine($"Контроллер {GetType().Name} получил сообщение");
            await _telegramClient.SendTextMessageAsync(message.Chat.Id, 
                $"Данный тип сообщений не поддерживается. Пожалуйста отправьте текст.", cancellationToken: ct);
        }
    }
}
