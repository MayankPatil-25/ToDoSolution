using Microsoft.Maui;
using Microsoft.Maui.Controls;
using ToDoApp.Mobile.Views;

namespace ToDoApp.Mobile;

public partial class App : Application
{
    private readonly ToDoListPage _page;
    public App(ToDoListPage page)
    {
        InitializeComponent();
        _page = page;
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new NavigationPage(_page));
    }
}