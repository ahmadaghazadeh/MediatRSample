using MediatR;

namespace API.Application.CreateWeatherForecast
{
    public class CreateWeatherForecastCommandHandler : IRequestHandler<CreateWeatherForecastCommand, Unit>
    {


        public CreateWeatherForecastCommandHandler(ApiContext apiContext)
        {
            this.apiContext = apiContext;
        }

        private readonly ApiContext apiContext;

        public async Task<Unit> Handle(CreateWeatherForecastCommand request, CancellationToken cancellationToken)
        {
            await apiContext.WeatherForecasts.AddAsync(new Models.WeatherForecast
            {
                Date = request.Date,
                Id = request.Id,
                Summary = request.Summary,
                TemperatureC = request.TemperatureC,
            }, cancellationToken);
            await apiContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;

        }

    }
}
