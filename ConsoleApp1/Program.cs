using System;
using Telegram.Bot;
using Telegram.Bot.Args;
namespace ConsoleApp1
{
    class Program
    {
        private static TelegramBotClient botClient;
        static void Main(string[] args)
        {
            //Token 
            //And time Out to send message
            botClient = new TelegramBotClient("666524039:AAHlNJEnIW8gXb1f4E6zsvnKyAjP9bjD4VQ") { Timeout = TimeSpan.FromSeconds(10) };
            var me = botClient.GetMeAsync().Result;
            // ID Bot
            Console.WriteLine($"bot id {me.Id}");
            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();
            Console.ReadKey();
        }
        private static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            var text = e?.Message?.Text;
            //Message != null
            if (text == null)
                return;
            string name = $"{e.Message.From.FirstName} {e.Message.From.LastName}";
            string chatIdClient = $"{e.Message.From.Id}";
            Console.WriteLine($"recived text message '{text}' відправив '{name}' ID чата клієнта '{chatIdClient}'  in chat '{e.Message.Chat.Id}'");
            //Bot Async message send to client
            await botClient.SendTextMessageAsync(
                chatId: e.Message.Chat,
                text: $"You said '{text}'"
                ).ConfigureAwait(false);
           
        }


    }
}
