using Microsoft.EntityFrameworkCore;

namespace WeatherApp.Models
{
    public class WeatherContext : DbContext
    {
        public DbSet<WeatherIcon> WeatherIcons { get; set; } 
        public WeatherContext(DbContextOptions<WeatherContext> options) : base(options)
        {

        }
    }
}
