﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherNotificationTelegramBot.Application.DTOs
{
    public record UserResponseHistoryDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TelegramUsername { get; set; }
        public List<string> WeatherRequestHistory { get; set; }
    }
}
