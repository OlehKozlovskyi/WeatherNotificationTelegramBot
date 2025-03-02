using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherNotificationTelegramBot.Application.DTOs;
using WeatherNotificationTelegramBot.BusinessLogic.Entities;

namespace WeatherNotificationTelegramBot.Application.Mapping
{
    public class UserResponseHistoryProfileMap : Profile
    {
        public UserResponseHistoryProfileMap()
        {
            CreateMap<User, UserResponseHistoryDto>()
                .ForMember(destinationMember => destinationMember.Id, options => options.MapFrom(sourceMember => sourceMember.id))
                .ForMember(destinationMember => destinationMember.FirstName, options => options.MapFrom(sourceMember => sourceMember.first_name))
                .ForMember(destinationMember => destinationMember.LastName, options => options.MapFrom(sourceMember => sourceMember.last_name))
                .ForMember(destinationMember => destinationMember.TelegramUsername, options => options.MapFrom(sourceMember => sourceMember.telegram_username))
                .ForMember(destinationMember => destinationMember.WeatherRequestHistory, options => options.MapFrom(sourceMember => sourceMember.weather_history));
        }
    }
}
