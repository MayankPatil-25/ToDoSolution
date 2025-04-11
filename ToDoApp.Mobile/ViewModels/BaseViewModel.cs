using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Java.Util.Concurrent;

namespace ToDoApp.Mobile.ViewModels;

public partial class BaseViewModel: INotifyPropertyChanged
{
    /// <summary>
    /// Common getter for Page object.
    /// </summary>
    protected Page PageInstance => App.Current?.MainPage;
    
    /// <summary>
    /// This should enable/disable the navigation bar on the page if binding is set.
    /// </summary>
    private bool _hasNavigationBar;
    public bool HasNavigationBar
    {
        get => _hasNavigationBar;
        set
        {
            _hasNavigationBar = value;
            OnPropertyChanged(nameof(HasNavigationBar));
        }
    }
    
    /// <summary>
    /// This should activate the loader on the page if binding is set.
    /// </summary>
    private bool _isBusy;
    public bool IsBusy
    {
        get => _isBusy;
        set
        {
            _isBusy = value;
            OnPropertyChanged(nameof(IsBusy));
        }
    }

    /// <summary>
    /// Invoked when the ContentPage is appearing.
    /// </summary>
    protected virtual void OnAppearing()
    {
        HasNavigationBar = false;
    }

    /// <summary>
    /// Invoked when the ContentPage is disappearing.
    /// </summary>
    protected virtual void OnDisappearing()
    {
        // We can implement the common logic for disposing the common objects if needed.
    }
   
    [RelayCommand]
    void Appearing() => OnAppearing();

    [RelayCommand]
    void Disappearing() => OnDisappearing();

    public event PropertyChangedEventHandler? PropertyChanged;
    
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected async Task DisplayPopup(string title, string message, string button = "Ok")
    {
       await PageInstance.DisplayAlert(title, message, button);
    }

    protected Task Navigate<TPage>() where TPage : ContentPage
    {
        var page = App.Services?.GetRequiredService<TPage>();
        if (page == null) return Task.CompletedTask;
        return PageInstance.Navigation.PushAsync(page, true);
    }
}