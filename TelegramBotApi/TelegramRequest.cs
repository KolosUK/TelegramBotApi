using SimpleJSON;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Timers;
using TelegramBotApi.Models;
using static TelegramBotApi.Program;

namespace TelegramBotApi
{
    class TelegramRequest
    {
        public string Token = "651081088:AAHIRo4tgLdNQU8lnzg5yZCjCjBicT6-qnE";
        public string Url = "https://api.telegram.org/bot";
        int LastUpdateID = 0;
        public event Response ResponseReceived;
        ParameterResponse e = new ParameterResponse();
        static Timer timer;

        public void GetUpdates()
        {

            schedule_Timer();
            while (true)
            {
                using (WebClient webClient = new WebClient())
                {
                    string response = webClient.DownloadString(Url + Token + "/getupdates?offset=" + (LastUpdateID + 1));
                    var N = JSON.Parse(response);
                    if (response.Length <= 23)
                        continue;
                    foreach (JSONNode r in N["result"].AsArray)
                    {
                        LastUpdateID = r["update_id"].AsInt;
                        e.name = r["message"]["from"]["first_name"];
                        e.message = r["message"]["text"];
                        e.chatID = r["message"]["chat"]["id"];
                    }

                    SendMessage send = new SendMessage();
                    send.SendMessageBase(e.chatID, e.message);
        
                }
                ResponseReceived(this, e);
            }
        }

        static void schedule_Timer()
        {
            Console.WriteLine("### Timer Started ###");

            DateTime nowTime = DateTime.Now;
            DateTime scheduledTime = new DateTime(nowTime.Year, nowTime.Month, nowTime.Day, 10, 00, 0, 0); //Specify your scheduled time HH,MM,SS [8am and 42 minutes]
            if (nowTime > scheduledTime)
            {
                scheduledTime = scheduledTime.AddDays(1);
            }

            double tickTime = (double)(scheduledTime - DateTime.Now).TotalMilliseconds;
            timer = new Timer(tickTime);
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Start();
        }

        static void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var chatID = "-1001692254923";
            Console.WriteLine("### Timer Stopped ### \n");
            SendMessage send = new SendMessage();
            send.SendMessageBase(chatID, "morning");
            schedule_Timer();
        }

    }
}
