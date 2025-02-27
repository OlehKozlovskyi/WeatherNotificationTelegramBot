using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherNotificationTelegramBot.Application.Entities
{
    public record WeatherResponse
    {
        public Main Main { get; init; }
        public Wind Wind { get; init; }
        public Sys Sys { get; init; }
        public string Name { get; init; }
    }
}
