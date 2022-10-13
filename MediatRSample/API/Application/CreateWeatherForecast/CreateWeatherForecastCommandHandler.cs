using API.Notification;
using MediatR;
using System.Net.NetworkInformation;

namespace API.Application.CreateWeatherForecast
{
    public class CreateWeatherForecastCommandHandler : IRequestHandler<CreateWeatherForecastCommand, Unit>
    {


        public CreateWeatherForecastCommandHandler(ApiContext apiContext,IMediator mediator)
        {
            this.apiContext = apiContext;
            this.mediator = mediator;
        }

        private readonly ApiContext apiContext;
        private readonly IMediator mediator;

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

            await mediator.Publish(new WeatherForecastAdded(request.Id));

            return Unit.Value;

        }

    }
}
