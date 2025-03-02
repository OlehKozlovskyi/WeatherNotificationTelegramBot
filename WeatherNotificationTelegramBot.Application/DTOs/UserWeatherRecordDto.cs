using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherNotificationTelegramBot.Application.DTOs
{
    public record UserWeatherRecordDto
    {
        public int Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string TelegramUsername { get; init; }
        public string RequestedCity { get; init; }
    }
}
