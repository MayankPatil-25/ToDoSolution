using Microsoft.Extensions.Logging;
using ToDoApp.Mobile.ViewModels;
using ToDoApp.Mobile.Views;
using CommunityToolkit.Maui;
using ToDoApp.Mobile.Services;

namespace ToDoApp.Mobile;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif
        // Registering App singleton to get the Services object ready to access at the earliest.
        builder.Services.AddSingleton<App>();
        
        // Registering HttpClient and Services
        builder.Services.AddSingleton<HttpClient>();
        builder.Services.AddSingleton<IToDoService, ToDoService>();
        
        // Registering Views/Pages
        builder.Services.AddTransient<ToDoListPage>();
        builder.Services.AddTransient<AddToDoPage>();
        
        // Registering ViewModels
        builder.Services.AddTransient<ToDoListViewModel>();
        builder.Services.AddTransient<AddToDoViewModel>();
        
        return builder.Build();
    }
}