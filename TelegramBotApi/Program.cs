using System;
using SimpleJSON;
using System.Net;
using System.Text;
using System.Threading;
using TelegramBotApi.Models;

namespace TelegramBotApi
{
    class Program
    {
        static void Main(string[] args)
        {
            TelegramRequest Tr = new TelegramRequest();
            Tr.ResponseReceived += Tr_ResponseReceived;
            Thread thr = new Thread(Tr.GetUpdates);
            thr.IsBackground = true;
            thr.Start();
            while (true)
            {
                Thread.Sleep(500);
            }
        }

        private static void Tr_ResponseReceived(object sendr, ParameterResponse e)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("{0}: {1}  chatId:{2}", e.name, e.message, e.chatID);
        }

        public delegate void Response(object sendr, ParameterResponse e);

    }
}
