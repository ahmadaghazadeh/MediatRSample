using API.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace API.Notification
{
    public class ConsoleWeatherForecastAddedHandler : INotificationHandler<WeatherForecastAdded>
    {
        private readonly ILogger<WeatherForecast> _logger;

        public ConsoleWeatherForecastAddedHandler(ILogger<WeatherForecast> logger)
        {
            _logger = logger;
        }
        public Task Handle(WeatherForecastAdded notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"WeatherForecast added {notification.Id}");
            return Task.CompletedTask;

        }
    }
}
