using System;
using Library;
using LibraryAPI;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Telegram.Bot.Types.ReplyMarkups;
using System.Linq;

namespace Library
{
    /* 
    Se aplica el patrón Adapter: La clase cliente es el CoreBot y la clase que brinda el servicio que necesitamos adaptar
    es la API de Telegram. La interfaz que usa el cliente es IMessageSender y IMessageReciver, por lo que como esta clase  
    es la clase que debe hacer compatibles los mensajes que se envian o llegan desde Telegram, implementa las interfaces 
    compatibles con el cliente 
    
    Se aplica el patron Chain of Responsibility 
    */
    public class TelegramGateway : IMessageSender, IMessageReceiver
    {
        public static long ChatID{get; private set;}
        public string callbackValue;
        public static void RunTelegramAPI()
        {
           
            TelegramBot telegramBot = TelegramBot.Instance;
            Console.WriteLine($"Hola soy el Bot de P2, mi nombre es {telegramBot.BotName} y tengo el Identificador {telegramBot.BotId}");
            ITelegramBotClient bot = telegramBot.Client;
            bot.OnMessage += OnMessage;
            bot.StartReceiving();
            Console.WriteLine("Presiona una tecla para terminar");
            Console.ReadKey();
            bot.StopReceiving();   

        }
        private static void OnMessage(object sender, MessageEventArgs messageEventArgs)
        {
            ITelegramBotClient client = TelegramBot.Instance.Client;
            Message message = messageEventArgs.Message;
            Chat chatInfo = message.Chat;
            string messageText = message.Text.ToLower();
             
            ChatID = chatInfo.Id;

            ICommandHandler commandsCommandHandler = new CommandsCommandHandler();
            ICommandHandler exitCommandHandler = new ExitCommandHandler();
            ICommandHandler startCommandHandler = new StartCommandHandler();
            ICommandHandler searchMyGiftCommandHandler = new SearchMyGiftCommandHandler();
            ICommandHandler aboutCommandHandler = new AboutCommandHandler();
            ICommandHandler commandNotFoundHandler = new CommandNotFoundHandlder();
            commandsCommandHandler.SetNext(exitCommandHandler);
            exitCommandHandler.SetNext(startCommandHandler);
            startCommandHandler.SetNext(searchMyGiftCommandHandler);
            searchMyGiftCommandHandler.SetNext(aboutCommandHandler);
            aboutCommandHandler.SetNext(commandNotFoundHandler);

            commandsCommandHandler.Handle(messageText, chatInfo);
        }

        public string GetInputAdapter(string res)
        {   
            callbackValue = res;

            return callbackValue;
        }
        public string GetInput()
        {
            string aux = callbackValue;

            return aux;
        }

        public void SendMessage(string message)
        {
           SendMessageTelegramAdapter(message);
        }

        public void SendMessageAnswers(Dictionary<string, string> ans)
        {
            ITelegramBotClient client = TelegramBot.Instance.Client;
            
            var rows = new List<List<InlineKeyboardButton>>();

            foreach (var index in ans)
            {
                List<InlineKeyboardButton> row = new List<InlineKeyboardButton>();

                InlineKeyboardButton button = InlineKeyboardButton.WithCallbackData(text: index.Value, callbackData: GetInputAdapter(index.Key));
                row.Add(button);
            }

            InlineKeyboardMarkup buttons = rows.Select(row => row.ToArray()).ToArray();
            
            client.SendTextMessageAsync(ChatID,"Elija una opción",replyMarkup: buttons);
        }

        public void SendMessageTelegramAdapter(string message)
        {
            ITelegramBotClient client = TelegramBot.Instance.Client;
            client.SendTextMessageAsync(chatId: ChatID, text: message);
        }
    }
}
