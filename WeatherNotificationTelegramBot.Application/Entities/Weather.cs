using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherNotificationTelegramBot.Application.Entities
{
    public record Weather(int Id, string Main, string Description, string Icon);
}
