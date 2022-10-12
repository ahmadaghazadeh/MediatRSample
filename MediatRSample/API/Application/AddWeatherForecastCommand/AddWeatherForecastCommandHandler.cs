using MediatR;

namespace API.Application.AddWeatherForecastCommand
{
    public class AddWeatherForecastCommandHandler : IRequestHandler<AddWeatherForecastCommand, Unit>
    {

        

        public AddWeatherForecastCommandHandler(ApiContext apiContext, ILogger logger)
        {
            this.apiContext = apiContext;
            this.logger = logger;
        }

        private readonly ApiContext apiContext;
        private readonly ILogger logger;

        public async Task<Unit> Handle(AddWeatherForecastCommand request, CancellationToken cancellationToken)
        {
            await apiContext.WeatherForecasts.AddAsync(new Models.WeatherForecast
            {
                Date = request.Date,
                Id = request.Id,
                Summary = request.Summary,
                TemperatureC = request.TemperatureC,
            }, cancellationToken);
            await apiContext.SaveChangesAsync(cancellationToken);
            logger.LogInformation($"WeatherForecast {request.Id} was added to the WeatherForecasts");
            return Unit.Value;

        }

    }
}
