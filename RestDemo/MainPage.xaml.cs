using RestDemo.MVVM.ViewModels;

namespace RestDemo
{
    public partial class MainPage : ContentPage
    {
        private int count = 0;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }
    }
}