using System;
using Library;
using LibraryAPI;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using System.IO;
using System.Text;

namespace Library
{
    public class TelegramGateway //: IMessageSender
    {
        public static void RunTelegramAPI()
        {
            //Obtengo una instancia de TelegramBot
            TelegramBot telegramBot = TelegramBot.Instance;
            Console.WriteLine($"Hola soy el Bot de P2, mi nombre es {telegramBot.BotName} y tengo el Identificador {telegramBot.BotId}");

            //Obtengo el cliente de Telegram
            ITelegramBotClient bot = telegramBot.Client;

            //Asigno un gestor de mensajes
            bot.OnMessage += OnMessage;

            //Inicio la escucha de mensajes
            bot.StartReceiving();

            Console.WriteLine("Presiona una tecla para terminar");
            Console.ReadKey();

            //Detengo la escucha de mensajes 
            bot.StopReceiving();   

        }
        private static void OnMessage(object sender, MessageEventArgs messageEventArgs)
        {
            ICommandHandler commandsCommandHandler = new CommandsCommandHandler();
            ICommandHandler exitCommandHandler = new ExitCommandHandler();
            ICommandHandler startCommandHandler = new StartCommandHandler();
            ICommandHandler commandNotFoundHandler = new CommandNotFoundHandlder();
            commandsCommandHandler.SetNext(exitCommandHandler);
            exitCommandHandler.SetNext(startCommandHandler);
            startCommandHandler.SetNext(commandNotFoundHandler);

            commandsCommandHandler.Handle(sender, messageEventArgs);
        }

        /* public void SendMessage(string message)
        {
            ITelegramBotClient client = TelegramBot.Instance.Client;
            await client.SendTextMessageAsync(
                                              chatId: chatInfo.Id,
                                              text: message
                                            );
        }  */

    }
}
