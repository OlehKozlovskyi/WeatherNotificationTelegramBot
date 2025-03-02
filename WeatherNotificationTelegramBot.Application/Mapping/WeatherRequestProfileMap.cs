using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using WeatherNotificationTelegramBot.Application.DTOs;
using WeatherNotificationTelegramBot.BusinessLogic.Entities;

namespace WeatherNotificationTelegramBot.Application.Mapping
{
    public class WeatherRequestProfileMap : Profile
    {
        public WeatherRequestProfileMap()
        {
            CreateMap<UserWeatherRecordDto, WeatherRequest>()
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.RequestedCity))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
