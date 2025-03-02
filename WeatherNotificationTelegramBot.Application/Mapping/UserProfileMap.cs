using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using WeatherNotificationTelegramBot.Application.DTOs;

namespace WeatherNotificationTelegramBot.Application.Mapping
{
    public class UserProfileMap : Profile
    {
        public UserProfileMap()
        {
            CreateMap<UserWeatherRecordDto, User>().ReverseMap();
        }
    }
}
