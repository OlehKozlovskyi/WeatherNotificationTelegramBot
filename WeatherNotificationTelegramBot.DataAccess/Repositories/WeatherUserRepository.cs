using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Options;
using MySqlConnector;
using WeatherNotificationTelegramBot.Application.Abstractions;
using WeatherNotificationTelegramBot.Application.DTOs;
using WeatherNotificationTelegramBot.DataAccess.Entities;

namespace WeatherNotificationTelegramBot.DataAccess.Repositories
{
    public class WeatherUserRepository : IWeatherUserRepository
    {
        //public WeatherUserRepository(string connectionString)
        //{
        //    _connectionString = connectionString;
        //}

        public async Task AddRecord(UserWeatherRecordDto recordDto)
        {
            var user = new User
            {
                Id = recordDto.Id,
                FirstName = recordDto.FirstName,
                LastName = recordDto.LastName,
                TelegramUsername = recordDto.TelegramUsername
            };

            var weatherRequest = new WeatherRequest
            {
                UserId = recordDto.Id,
                Location = recordDto.RequestedCity
            };

            string insertUser = @"INSERT IGNORE INTO Users (id, first_name, last_name, telegram_username) VALUES (@Id, @FirstName, @LastName, @TelegramUsername)";
            string insertRequestedCity = @"INSERT INTO WeatherRequestsHistory (user_id, location) VALUES (@UserId, @Location)";
            using var connection = new MySqlConnection("Server=localhost; User ID=root; Password=1111; Database=TelegramDatabase");
            await connection.OpenAsync();
            using var transaction = await connection.BeginTransactionAsync();
            try
            {
                await connection.ExecuteAsync(insertUser, user, transaction);
                await connection.ExecuteAsync(insertRequestedCity, weatherRequest,transaction);
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
