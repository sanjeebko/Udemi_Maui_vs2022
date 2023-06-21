using CollectionViewDemo.MVVM.ViewModels;

namespace CollectionViewDemo.MVVM.Views;

public partial class LayoutPage : ContentPage
{
    public LayoutPage()
    {
        InitializeComponent();
        BindingContext = new DataViewModel();
    }
}