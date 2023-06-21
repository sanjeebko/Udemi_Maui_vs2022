using MauiVerter.MVVM.ViewModels;

namespace MauiVerter.MVVM.Views;

public partial class ConverterView : ContentPage
{
    public ConverterView()
    {
        InitializeComponent();
    }

    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        (BindingContext as ConverterViewModel).Convert();
    }
}