using API.Application.CreateWeatherForecast;
using API.Models;
using API.Models.WeatherForecastQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private IMediator mediator;
        
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMediator mediator)
        {
            _logger = logger;
            this.mediator = mediator;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IList<WeatherForecast>> Get()
        {
            var forecasts = await mediator.Send(new WeatherForecastsQuery());
            return forecasts.WeatherForecastList;
        }
 
        [HttpPost(Name = "AddWeatherForecast")]
        public async Task add(CreateWeatherForecastCommand command)
        {
            await mediator.Send(command);         
        }
    }
}
