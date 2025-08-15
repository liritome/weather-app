using System.Globalization;
using Microsoft.Extensions.Options;
using WeatherApp.Services;

namespace WeatherApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<LocationService>();
            builder.Services.AddMemoryCache();
            builder.Services.AddHttpClient<WeatherApiService>();

            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromDays(1);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            var app = builder.Build();

            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-US");
            var localizationOptions = app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value;

            app.UseStatusCodePagesWithReExecute("/Error/{0}");
            app.UseRequestLocalization(localizationOptions);
            app.UseStaticFiles();
            app.UseSession();

            app.MapControllerRoute(
                name: "geocoder",
                pattern: "Geocoder/{action}/{id?}",
                defaults: new { controller = "Geocoder" }
            );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Weather}/{action=Now}/{city?}"
            );

            app.Run();
        }
    }
}
