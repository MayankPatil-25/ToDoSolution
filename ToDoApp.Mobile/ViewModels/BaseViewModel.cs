using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;

namespace ToDoApp.Mobile.ViewModels;


public abstract partial class BaseViewModel: INotifyPropertyChanged
{
    
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
    protected abstract void OnAppearing();
    
    /// <summary>
    /// Invoked when the ContentPage is disappearing.
    /// </summary>
    protected abstract void OnDisappearing();
   
    [RelayCommand]
    void Appearing() => OnAppearing();

    [RelayCommand]
    void Disappearing() => OnDisappearing();

    public event PropertyChangedEventHandler? PropertyChanged;
    
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}