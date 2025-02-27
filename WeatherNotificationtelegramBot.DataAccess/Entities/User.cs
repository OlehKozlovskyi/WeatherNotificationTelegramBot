using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherNotificationtelegramBot.DataAccess.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TelegramUsername {  get; set; }
        public int TelegramChatId { get; set; }
        public List<WeatherRequest> WeatherHistory { get; set; }
    }
}
