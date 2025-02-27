namespace WeatherNotificationtelegramBot.DataAccess.Entities
{
    public class WeatherRequest
    {
        public Guid RequestId { get; set; }
        public string RequestLocation {  get; set; }
        public DateTime RequestCreationDate { get; set; }
    }
}