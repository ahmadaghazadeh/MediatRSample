namespace API.Models
{
    public class WeatherForecastsResponse
    {
        public IList<WeatherForecast> WeatherForecastList { get; set; }

        public WeatherForecastsResponse(IList<WeatherForecast> weatherForecastList)
        {
            WeatherForecastList = weatherForecastList;
        }
    }
}
