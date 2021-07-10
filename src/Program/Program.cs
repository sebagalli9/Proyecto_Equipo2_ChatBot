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

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
         
            CoreBot.Instance.Awake();
            TelegramGateway.RunTelegramAPI();

        }
    }
}