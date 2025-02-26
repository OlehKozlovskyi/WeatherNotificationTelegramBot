using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherNotificationTelegramBot.Application.Entities
{
    public record Main(double Temp, double Feels_Like, int Pressure);
}
