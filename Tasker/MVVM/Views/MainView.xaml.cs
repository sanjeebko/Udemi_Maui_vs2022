using Tasker.MVVM.ViewModels;

namespace Tasker.MVVM.Views;

public partial class MainView : ContentPage
{
    private MainViewModel MainViewModel { get; } = new MainViewModel();

    public MainView()
    {
        InitializeComponent();
        BindingContext = MainViewModel;
    }

    private void checkBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        MainViewModel.UpdateData();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        var taskView = new NewTaskView
        {
            BindingContext = new NewTaskViewModel
            {
                Tasks = MainViewModel.Tasks,
                Categories = MainViewModel.Categories,
            }
        };
        Navigation.PushAsync(taskView);
    }
}