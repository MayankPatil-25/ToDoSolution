using ToDoApp.Mobile.ViewModels;

namespace ToDoApp.Mobile.Views;

public partial class ToDoItemDetailPage : BaseContentPage
{
    public ToDoItemDetailPage(ToDoItemDetailViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}