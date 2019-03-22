using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

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

                    if ( Message.ToLower().Contains("артуррр") ) {
                        pars.Add("chat_id", ChatID);
                        pars.Add("text", "Сіські!!!");
                        webClient.UploadValues(Url + Token + "/sendMessage", pars);
                    }

                    if ( Message.ToLower().Contains("артуррр") ) {
                        List<string> result = new List<string>();
                        using ( StreamReader r = new StreamReader("../../../StringsImg.json") ) {
                            var json = r.ReadToEnd();
                            var jobj = JObject.Parse(json);
                            foreach ( var item in jobj.Properties()) {
                                foreach ( var img in item.Value ) {
                                    result.Add(img.ToString());
                                }                        
                            }
                        }
                        Random rnd = new Random();
                        int photoId = rnd.Next(result.Count);
                        string randomImg = result[photoId];
                        pars.Add("chat_id", ChatID);
                        pars.Add("photo", randomImg);
                        pars.Add("caption", "");
                        webClient.UploadValues(Url + Token + "/sendPhoto", pars);
                    }

                    if ( Message.Contains("Я жму") | Message.Contains("я жму") ) {
                        pars.Add("chat_id", ChatID);
                        var resultString = Regex.Match(Message, @"\d+").Value;
                        if ( Decimal.TryParse(resultString, out var number) ) {
                            if ( number < 80 ) {
                                pars.Add("text", "Дрищ йди в зал і нормально займайся блеат!!!");
                            } else if ( number >= 80 && number <= 120 ) {
                                pars.Add("text", "Не плохо але їбош дальше");
                            } else if ( number >= 121 && number <= 150 ) {
                                pars.Add("text", "Ти машина");
                            } else if ( number > 151 ) {
                                pars.Add("text", "Ну ти і піздюк");
                            }

                        } else {
                            pars.Add("text", "Напиши нормально і не вимахуйся");
                        }
  
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
                        pars.Add("text", "Верогідність(вираховує вирогідність виникнення події), Чи(чи певна подія відбудетсья), Слава Україні, Хто(вираховує хто той самий), Я жму ( пишеш скільки кг і він пизначає хто ти є в залі), Артуррр(Фіча для Качетка)");
                        webClient.UploadValues(Url + Token + "/sendMessage", pars);
                    }
                }
            }
        }
    }
}
