using Microsoft.AspNetCore.Mvc;
using WeatherNotificationTelegramBot.Application.Abstractions;
using WeatherNotificationTelegramBot.Application.DTOs;

namespace WeatherNotificationTelegramBot.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class WeatherUserController(IWeatherUserService userService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateUserWeatherRecord([FromBody] UserWeatherRecordDto recordDto)
        {
            await userService.AddWeatherUserEntryAsync(recordDto);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await userService.GetUserById(id);
            return Ok(user);
        }
    }
}
