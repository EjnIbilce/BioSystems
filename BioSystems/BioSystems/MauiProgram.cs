using BioSystems.Data;
using BioSystems.Models;
using BioSystems.Services;
using BioSystems.ViewModels;
using BioSystems.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BioSystems
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("MaterialIcons-Regular.ttf", "MaterialIcons");
                });

            var connectionString = AppDbContext.LoadConnectionString();
            bool isFirstTime = Preferences.Get("HasSeenOnboarding", false);

            builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

            builder.Services.AddScoped<UserService>();

            builder.Services.AddTransient<RegisterPage>();
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<IntroScreenView>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
