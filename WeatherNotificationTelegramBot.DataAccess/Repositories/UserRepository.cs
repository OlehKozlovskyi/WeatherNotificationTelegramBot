﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Azure.Identity;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using WeatherNotificationTelegramBot.DataAccess.Entities;

namespace WeatherNotificationTelegramBot.DataAccess.Repositories
{
    public class UserRepository
    {
        private readonly string _connectionString;

        public UserRepository(string connectionString) 
        {
            _connectionString = connectionString;
        }

        public async Task AddUser(string id, string firstName, string lastName, string telegramUsername)
        {
            var builder = new MySqlConnectionStringBuilder 
            {
                Server = "localhost",
                Database = "TelegramDatabase",
                UserID = "root",
                Password = "1111"
            };
            var user = new User
            {
                Id = 123,
                FirstName = "Oleh",
                LastName = "Kozlovskiy",
                TelegramUsername = "@ChrisB"
            };
            string connectionString = builder.ConnectionString;
            string query = @"INSERT IGNORE INTO Users (Id, FirstName, LastName, TelegramUsername) VALUES (@Id, @FirstName, @LastName, @TelegramUsername)";
            await using var connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync(query, user);
        }
    }
}
