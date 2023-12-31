﻿using CS_Basic.Module_11_Task_2_4;
using CS_Basic.TeLen_bot.Controllers;
using CS_Basic.TeLen_bot.Models;
using CS_Basic.TeLen_bot.Services;
using CS_Basic.TeLen_bot.Utilities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text;
using Telegram.Bot;

namespace CS_Basic.TeLen_bot
{
    internal class Program
    {
        public static async Task Main()
        {
            Console.OutputEncoding = Encoding.Unicode;

            // Объект, отвечающий за постоянный жизненный цикл приложения
            var host = new HostBuilder()
                .ConfigureServices((hostContext, services) => ConfigureServices(services)) // Задаем конфигурацию
                .UseConsoleLifetime() // Позволяет поддерживать приложение активным в консоли
                .Build(); // Собираем

            Console.WriteLine("Сервис запущен");
            // Запускаем сервис
            await host.RunAsync();
            Console.WriteLine("Сервис остановлен");
        }

        static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<TextFunctions>();
            //services.AddTransient<IStorage, MemoryStorage>();
            services.AddTransient<TextMessageController>();
            services.AddTransient<DefaultMessageController>();
            services.AddTransient<InlineKeyboardController>();
            // Регистрируем объект TelegramBotClient c токеном подключения
            services.AddSingleton<ITelegramBotClient>(provider => new TelegramBotClient("6635203821:AAFevqGTbmQkeu-YiilAQlcgFXFNdUNw414"));
            // Регистрируем постоянно активный сервис бота
            services.AddHostedService<Bot>();
        }
    }
}