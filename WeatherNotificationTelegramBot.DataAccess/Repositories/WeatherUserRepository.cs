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
using WeatherNotificationTelegramBot.BusinessLogic.Entities;

namespace WeatherNotificationTelegramBot.DataAccess.Repositories
{
    public class WeatherUserRepository : IWeatherUserRepository
    {
        private readonly string _connectionString = "Server=localhost; User ID=root; Password=1111; Database=TelegramDatabase";

        public async Task AddRecord(User user, WeatherRequest weatherRequest)
        {
            string insertUser = @"INSERT IGNORE INTO Users (id, first_name, last_name, telegram_username) VALUES (@Id, @FirstName, @LastName, @TelegramUsername)";
            string insertRequestedCity = @"INSERT INTO WeatherRequestsHistory (user_id, location) VALUES (@UserId, @Location)";
            using var connection = new MySqlConnection(_connectionString);
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

        public async Task<User> GetUserByIdAsync(int id)
        {
            string query = @"SELECT u.id, u.first_name, u.last_name, u.telegram_username, w.id AS weather_request_id, 
                    w.location
                FROM Users u
                LEFT JOIN WeatherRequestsHistory w ON u.id = w.user_id
                WHERE u.id = @UserId;";
            var userDictionary = new Dictionary<int, User>();
            using var connection = new MySqlConnection(_connectionString);
            var result = await connection.QueryAsync<User, WeatherRequest, User>(
                query,
                (user, weatherRequest) =>
                {

                    if (userDictionary.TryGetValue(user.id, out var existingUser))
                    {
                        user = existingUser;
                    }
                    else
                    {
                        userDictionary.Add(user.id, user);
                        user.weather_history = new List<string>();
                    }
                    user.weather_history.Add(weatherRequest.Location);
                    return user;
                },
                new { UserId = id },
                splitOn: "weather_request_id"
            );
            return result.First();
        }

        public async Task<List<User>> GetUsersAsync()
        {
            string query = @"SELECT * FROM Users";
            using var connection = new MySqlConnection(_connectionString);
            var result = await connection.QueryAsync<User>(query);
            return result.ToList();
        }
    }
}
