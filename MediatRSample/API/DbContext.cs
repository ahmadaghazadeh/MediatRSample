using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public class ApiContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase(databaseName: "WeatherForecast");
        }

        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    
    }
}
