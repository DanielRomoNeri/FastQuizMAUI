using FastQuizMAUI.Pages;
using FastQuizMAUI.Services;
using FastQuizMAUI.ViewModels;
using Microsoft.Extensions.Logging;

namespace FastQuizMAUI
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
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<DatabaseService>()
                .AddTransient<MainPage>()
                .AddTransient<MainPageVM>()
                .AddTransient<CreateBoxForm>()
                .AddTransient<CreateBoxFormVM>()
                .AddTransient<InsideBoxPage>()
                .AddTransient<InsideBoxVM>()
                .AddTransient<AddItemForm>();
            return builder.Build();
        }
    }
}
