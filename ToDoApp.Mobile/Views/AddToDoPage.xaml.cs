using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Mobile.ViewModels;

namespace ToDoApp.Mobile.Views;

public partial class AddToDoPage : BaseContentPage
{
    public AddToDoPage(AddToDoViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}