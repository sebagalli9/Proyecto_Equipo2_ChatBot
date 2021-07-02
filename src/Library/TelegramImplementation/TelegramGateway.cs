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

        public string GetInput()
        {
            return null;
        }

        public void SendMessage(string message)
        {
           SendMessageTelegramAdapted(message);
        }

        public void SendMessageAnswers(Dictionary<string, string> ans)
        {
            //aca se puede hacer lo de imprimir los botones
            //lo que llega en el diccionario es tipo: 1-mujer
            //el usuario tiene que ver escrito en el boton o 1 o mujer
            //el boton tiene que devolver si o si el valor 
            
            /* List<InlineKeyboardButton> keyboardButtons = new List<InlineKeyboardButton>();

            foreach(var option in ans)
            {
                InlineKeyboardButton button = InlineKeyboardButton.WithCallbackData(
                            text: option.Value,
                            callbackData: option.Key);
                

                 keyboardButtons.Add(button);
            }

            ITelegramBotClient client = TelegramBot.Instance.Client;
            client.SendTextMessageAsync(
                        ChatID,
                        "Elija una opción",
                        replyMarkup: keyboardButtons);    */
            
            
            

        }

        
        public void SendMessageTelegramAdapted(string message)
        {
            ITelegramBotClient client = TelegramBot.Instance.Client;
            client.SendTextMessageAsync(chatId: ChatID, text: message);
        }
        



    }
}
