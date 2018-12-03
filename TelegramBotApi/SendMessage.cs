using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Text;

namespace TelegramBotApi
{
    class SendMessage
    {
        public string Token = "651081088:AAHIRo4tgLdNQU8lnzg5yZCjCjBicT6-qnE";
        public string Url = "https://api.telegram.org/bot";

        public void SendMessageBase(string ChatID, string Message)
        {
            if (Message != null)
            {
                using (WebClient webClient = new WebClient())
                {
                    NameValueCollection pars = new NameValueCollection();
                    if (Message.Contains("Верогідність"))
                    {
                        Random random = new Random();
                        int randomPersent = random.Next(0, 100);
                        pars.Add("chat_id", ChatID);
                        pars.Add("text", "Верогідність " + randomPersent + " %");
                        webClient.UploadValues(Url + Token + "/sendMessage", pars);
                    }

                    if (Message.Contains("Чи") || Message.Contains(" чи "))
                    {
                        Random random = new Random();
                        int randomArea = random.Next(0, 1000);
                        pars.Add("chat_id", ChatID);
                        if (randomArea > 500)
                        {
                            pars.Add("text", "Так");
                        }
                        else
                        {
                            pars.Add("text", "Ні");
                        }

                        webClient.UploadValues(Url + Token + "/sendMessage", pars);
                    }

                    if (Message.Contains("Слава Україні"))
                    {
                        pars.Add("chat_id", ChatID);
                        pars.Add("text", "Героям Слава!!!");
                        webClient.UploadValues(Url + Token + "/sendMessage", pars);
                    }

                    if (Message.Contains("Хто"))
                    {
                        string[] pepole = {"Колос", "Сива", "Ніка", "Вуйко Тарас", "Володька", "Качетко", "Пелишка", "Макар", "Стьопа", "Жора", "Рижулька", "Софа Карпишин", "Джуля", "Римар", "Чопік", "Єнот", "Маша", "Серго", "Самий сексуальний Бодя", "Шаріф", "Чурка" };
                        Random rnd = new Random();
                        int person = rnd.Next(pepole.Length);
                        pars.Add("chat_id", ChatID);
                        pars.Add("text", pepole[person]);
                        webClient.UploadValues(Url + Token + "/sendMessage", pars);
                    }
                    if (Message.Contains("Команди"))
                    {
                        pars.Add("chat_id", ChatID);
                        pars.Add("text", "Верогідність(вираховує вирогідність виникнення події), Чи(чи певна подія відбудетсья), Слава Україні, Хто(вираховує хто той самий)");
                        webClient.UploadValues(Url + Token + "/sendMessage", pars);
                    }
                }
            }
        }
    }
}
