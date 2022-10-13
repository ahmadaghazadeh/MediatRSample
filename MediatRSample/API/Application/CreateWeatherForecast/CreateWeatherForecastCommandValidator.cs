using FluentValidation;

namespace API.Application.CreateWeatherForecast
{
    public class CreateWeatherForecastCommandValidator : AbstractValidator<CreateWeatherForecastCommand>
    {
        public CreateWeatherForecastCommandValidator()
        {
            RuleFor(x=>x.Id).NotEqual(0);
            RuleFor(x => x.TemperatureC).GreaterThanOrEqualTo(-273);
            RuleFor(x=>x.Summary).NotEmpty();
        }
    }
}
