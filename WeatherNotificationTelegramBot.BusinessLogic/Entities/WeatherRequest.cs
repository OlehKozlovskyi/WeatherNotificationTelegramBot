using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherNotificationTelegramBot.BusinessLogic.Entities
{
    public class WeatherRequest
    {
        public string Location { get; set; }
        public int UserId { get; set; }

        public WeatherRequest() { }
    }
}
