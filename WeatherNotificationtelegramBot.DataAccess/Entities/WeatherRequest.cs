using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherNotificationTelegramBot.DataAccess.Entities
{
    public class WeatherRequest
    {
        public string Location {  get; set; }
        public string UserId {  get; set; }
    }
}
