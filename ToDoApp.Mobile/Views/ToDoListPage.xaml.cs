using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Mobile.ViewModels;

namespace ToDoApp.Mobile.Views;

public partial class ToDoListPage : BaseContentPage
{
    public ToDoListPage(ToDoListViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}