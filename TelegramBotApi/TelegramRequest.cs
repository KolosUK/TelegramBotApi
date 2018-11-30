using SimpleJSON;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
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

        public void GetUpdates()
        {
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
    }
}
