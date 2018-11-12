using System;
using System.Collections.Generic;
using System.Text;

namespace TelegramBotApi.Models
{
    class ParameterResponse : EventArgs
    {
        public string name;
        public string message;
        public string chatID;
    }
}
