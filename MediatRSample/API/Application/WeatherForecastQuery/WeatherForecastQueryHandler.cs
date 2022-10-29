using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Models.WeatherForecastQuery
{
    public class WeatherForecastQueryHandler : IRequestHandler<WeatherForecastsQuery, WeatherForecastsResponse>
    {
        private readonly ApiContext _context;

        public WeatherForecastQueryHandler(ApiContext context)
        {
            _context = context;
        }
        public async Task<WeatherForecastsResponse> Handle(WeatherForecastsQuery request, CancellationToken cancellationToken)
        {
            var model = await _context.WeatherForecasts.ToListAsync(cancellationToken);
            return new WeatherForecastsResponse(model);
        }
    }
}
