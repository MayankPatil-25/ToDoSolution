using System.Net.Http;
using Microsoft.Extensions.Logging;
using ToDoApp.Mobile.ViewModels;
using ToDoApp.Mobile.Views;
using CommunityToolkit.Maui;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
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
        builder.Services.AddSingleton<App>();
        
        // Registering HttpClient and Services
        builder.Services.AddSingleton<HttpClient>();
        builder.Services.AddSingleton<IToDoService, ToDoService>();
        
        builder.Services.AddSingleton<ToDoListPage>();
        builder.Services.AddTransient<ToDoListViewModel>();
        
        builder.Services.AddTransient<AddToDoPage>();
        builder.Services.AddSingleton<AddToDoViewModel>();
        
        return builder.Build();
    }
}