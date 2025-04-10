using Microsoft.Maui;
using Microsoft.Maui.Controls;
using ToDoApp.Mobile.Views;

namespace ToDoApp.Mobile;

public partial class App : Application
{
    public static IServiceProvider Services { get; private set; }

    public App(IServiceProvider services)
    {
        InitializeComponent();
        Services = services;
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        var page = Services.GetRequiredService<ToDoListPage>();
        return new Window(new NavigationPage(page));
    }
}