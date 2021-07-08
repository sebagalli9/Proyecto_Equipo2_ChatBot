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

    Se cumple ISP
    */
    public class TelegramGateway : IMessageSender, IMessageReceiver
    {
        public static long ChatID{get; private set;}
        public static string callbackValue;
        public static bool BottonClickedCompleted {get; private set;}
        public static void RunTelegramAPI()
        { 
            TelegramBot telegramBot = TelegramBot.Instance;
            Console.WriteLine($"Hola soy el Bot de P2, mi nombre es {telegramBot.BotName} y tengo el Identificador {telegramBot.BotId}");
            ITelegramBotClient bot = telegramBot.Client;
            bot.OnMessage += OnMessage;
            bot.OnCallbackQuery += BotOnCallbackQueryRecieved;
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

            if(!Session.userSessions.ContainsKey(chatInfo.Id))
            {
                Request request = new Request("initial");
                Session.userSessions.Add(chatInfo.Id,request);
            }

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
        //Este metodo deberia esperar a que alguien aprente el boton para retornar, asi el valor de callback ya esta actualizado
        { 
            return callbackValue;

        }

        public void SendMessage(string message)
        {
           SendMessageTelegramAdapter(message);
        }

        public void SendMessageTelegramAdapter(string message)
        {
            ITelegramBotClient client = TelegramBot.Instance.Client;
            client.SendTextMessageAsync(chatId: ChatID, text: message);
        }

        public void SendMessageAnswers(Dictionary<string, string> ans)
        {
            callbackValue = "";
            SendMessageAnswersAdapter(ans);
            
        }

        public async void SendMessageAnswersAdapter(Dictionary<string, string> ans)
        {
            ITelegramBotClient client = TelegramBot.Instance.Client;        
            
             var rows = new List<List<InlineKeyboardButton>>();

            foreach (var index in ans)
            {
                InlineKeyboardButton button = InlineKeyboardButton.WithCallbackData(text: index.Value, callbackData: index.Key);

                rows.Add(
                    new List<InlineKeyboardButton>
                    {
                         button
                    });

            }
             var keyBoard = new InlineKeyboardMarkup(rows);

           
                await client.SendTextMessageAsync(
                    ChatID,
                    "Seleccione una de las siguientes opciones:",
                    replyMarkup: keyBoard 
                );
        }

        private static async void BotOnCallbackQueryRecieved(object sender, CallbackQueryEventArgs callbackQueryEventArgs)
        {
            var callbackQuery = callbackQueryEventArgs.CallbackQuery;
           
            ITelegramBotClient client = TelegramBot.Instance.Client;                    
             
            ChatID = callbackQuery.Message.Chat.Id;

            await client.SendTextMessageAsync(
                    callbackQuery.Message.Chat.Id,
                    $"¡Entendido!"
                );

             callbackValue = callbackQuery.Data; 
             UpdateBottonClickedCompleted(true);
             
        }

        public static void UpdateBottonClickedCompleted(bool b)
        {
            BottonClickedCompleted = b;
        }
    }
}
