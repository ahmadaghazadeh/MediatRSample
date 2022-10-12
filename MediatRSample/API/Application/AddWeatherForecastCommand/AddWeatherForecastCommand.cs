using MediatR;

namespace API.Application.AddWeatherForecastCommand
{
    public class AddWeatherForecastCommand: IRequest
    {
        public int Id { get; set; }
        public DateTime Date { get;  }

        public int TemperatureC { get;  }

        public string? Summary { get;  }
        public AddWeatherForecastCommand(int id,DateTime dateTime,int tempertureC,string? summary)
        {
            Id= id; 
            Date= dateTime; 
            TemperatureC= tempertureC;
            Summary= summary;
        }
    }
}
