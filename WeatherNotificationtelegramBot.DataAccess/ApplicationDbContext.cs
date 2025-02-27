using Microsoft.EntityFrameworkCore;

namespace WeatherNotificationtelegramBot.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) { }
    }
}
