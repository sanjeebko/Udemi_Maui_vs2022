using MauiCalc.MVVM.ViewModels;

namespace MauiCalc.MVVM.Views;

public partial class CalcView : ContentPage
{
    public CalcView()
    {
        InitializeComponent();
        BindingContext = new CalcViewModel();
    }
}