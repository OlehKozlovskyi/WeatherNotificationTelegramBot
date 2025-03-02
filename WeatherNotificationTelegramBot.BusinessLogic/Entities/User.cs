using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherNotificationTelegramBot.BusinessLogic.Entities
{
    public class User
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string telegram_username { get; set; }

        public List<string> weather_history { get; set; }

        public User() { }
    }
}
