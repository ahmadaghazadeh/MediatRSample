using API.Models;
using MediatR;

namespace API.Notification
{
    public class ConsleMoreInfoWeatherForesatAddedHandler : INotificationHandler<WeatherForecastAdded>
    {
        private readonly ILogger<WeatherForecast> _logger;

        public ConsleMoreInfoWeatherForesatAddedHandler(ILogger<WeatherForecast> logger)
        {
            _logger = logger;
        }
        public Task Handle(WeatherForecastAdded notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"WeatherForecast added more info {notification.Id}");
            return Task.CompletedTask;

        }
    }
}
