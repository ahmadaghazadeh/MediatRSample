using MediatR;

namespace API.Notification
{
    public class WeatherForecastAdded:INotification
    {
        public int Id { get; }

        public WeatherForecastAdded(int id)
        {
            Id = id;
        }
    }
}
