using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Mobile.Controls;

public partial class TDLoaderView : ContentView
{
    public static readonly BindableProperty IsLoadingEnabledProperty = BindableProperty.Create(
        nameof(IsLoadingEnabled),
        typeof(bool),
        typeof(TDLoaderView),
        false
    );
    
    public bool IsLoadingEnabled
    {
        get => (bool)GetValue(IsLoadingEnabledProperty);
        set
        {
            System.Diagnostics.Debug.WriteLine($"Setting IsLoadingEnabled to {value}");
            SetValue(IsLoadingEnabledProperty, value);
        }
    }
    public TDLoaderView()
    {
        InitializeComponent();
    }
}