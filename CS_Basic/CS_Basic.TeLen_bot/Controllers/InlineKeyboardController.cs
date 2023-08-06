using CS_Basic.TeLen_bot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace CS_Basic.TeLen_bot.Controllers
{
    public class InlineKeyboardController
    {
        private readonly Session _session;
        private readonly ITelegramBotClient _telegramClient;
        public InlineKeyboardController(ITelegramBotClient telegramClient,
                                        Session session)
        {
            _session= session;
            _telegramClient = telegramClient;
        }
        public async Task Handle(CallbackQuery? callbackQuery, CancellationToken ct)
        {
            Console.WriteLine($"Контроллер {GetType().Name} обнаружил нажатие на кнопку {callbackQuery.Data}");


            await _telegramClient.SendTextMessageAsync(callbackQuery.From.Id, $"Обнаружено нажатие на кнопку", cancellationToken: ct);
        }
    }
}
