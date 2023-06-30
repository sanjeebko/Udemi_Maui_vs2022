using SqLiteDemo.MVVM.ViewModels;

namespace SqLiteDemo.MVVM.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new MainPageViewModel();
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
    }
}