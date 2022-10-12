using MediatR;

namespace API.Models
{
    public class WeatherForecastsQuery:IRequest<WeatherForecastsResponse>
    {
    }
}
