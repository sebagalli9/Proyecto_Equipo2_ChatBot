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
        POLIMORFISMO: Se cumple con el patrón de polimorfismo ya que las clases 
        está implementando las operaciones polimórficas de sus interfaces.

        SRP: La clase cumple con el principio SRP ya que la única razón de cambio 
        es administrar los envíos y recepciones de mensajes de Telegram.

        ISP: La clase cumple con el principio ISP ya que no depende de un tipo que no usa.

        CHAIN OF RESPONSIBILITY: En esta clase se aplica el patrón Chain of Responsibility 
        para que varios objetos gestionen las diferentes comandos y así favorecer la extensibilidad.

        ADAPTER: La clase implementa el patrón Adapter para transformar a un formato 
        reconocible para el manejo de mensajes (inputs y outputs) en el core del bot.
    */

    public class TelegramGateway : IMessageSender, IMessageReceiver
    {
        private static string callbackValue;
        private static ICommandHandler commandsCommandHandler;
        private static ICommandHandler startCommandHandler;
        private static ICommandHandler searchMyGiftCommandHandler;
        private static ICommandHandler aboutCommandHandler;
        private static ICommandHandler commandNotFoundHandler;
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

            //Agrega usuarios nuevos al diccionario UserSessions de CoreBot
            if (!CoreBot.Instance.UserSessions.ContainsKey(chatInfo.Id))
            {
                Request request = new Request("initial", chatInfo.Id);
                CoreBot.Instance.AddUserSessions(chatInfo.Id, request);
            }

            //Construye cadena de responsabilidad para manejar los comandos
            commandsCommandHandler = new CommandsCommandHandler();
            startCommandHandler = new StartCommandHandler();
            searchMyGiftCommandHandler = new SearchGiftCommandHandler();
            aboutCommandHandler = new AboutCommandHandler();
            commandNotFoundHandler = new CommandNotFoundHandlder();

            commandsCommandHandler.SetNext(startCommandHandler);
            startCommandHandler.SetNext(searchMyGiftCommandHandler);
            searchMyGiftCommandHandler.SetNext(aboutCommandHandler);
            aboutCommandHandler.SetNext(commandNotFoundHandler);

            //Envia el mensaje recibido al primer eslabon de la cadena de responsabilidad
            commandsCommandHandler.Handle(messageText, chatInfo.Id);
        }
  
        public string GetInput()
        {
            //Recibe el valor de callback del botón y lo envia como input de usuario
            return callbackValue;
        }

        public void SendMessage(string message, long requestId)
        {
            SendMessageTelegramAdapter(message, requestId);
        }

        private void SendMessageTelegramAdapter(string message, long requestId)
        {
            //Imprime un mensaje en el chat de Telegram
            ITelegramBotClient client = TelegramBot.Instance.Client;
            client.SendTextMessageAsync(chatId: requestId, text: message);
        }

        public void SendMessageAnswers(Dictionary<string, string> ans, long requestId)
        {
            callbackValue = "";
            SendMessageAnswersAdapter(ans, requestId);
        }

        private async void SendMessageAnswersAdapter(Dictionary<string, string> ans, long requestId)
        {
            ITelegramBotClient client = TelegramBot.Instance.Client;

            //Mostrar botones de opciones de respuesta
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
                requestId,
                "Seleccione una de las siguientes opciones:",
                replyMarkup: keyBoard
            );
        }

        private static async void BotOnCallbackQueryRecieved(object sender, CallbackQueryEventArgs callbackQueryEventArgs)
        {
            var callbackQuery = callbackQueryEventArgs.CallbackQuery;

            ITelegramBotClient client = TelegramBot.Instance.Client;

            await client.SendTextMessageAsync(
                    callbackQuery.Message.Chat.Id,
                    $"¡Entendido!"
                );

            callbackValue = callbackQuery.Data;
        }
    }
}
