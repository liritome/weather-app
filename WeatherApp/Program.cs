using Microsoft.EntityFrameworkCore;
using WeatherApp.Models;

namespace WeatherApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            string connection = builder.Configuration.GetConnectionString("MsSqlServerConnection");
            builder.Services.AddDbContext<WeatherContext>(op => op.UseSqlServer(connection));
            builder.Services.AddControllersWithViews();
            var app = builder.Build();

            app.UseStaticFiles();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}");

            app.Run();
        }
    }
}
