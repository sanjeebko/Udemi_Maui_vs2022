using SqLiteDemo.MVVM.Views;
using SqLiteDemo.Repositories;

namespace SqLiteDemo
{
    public partial class App : Application
    {
        public static CustomerRepository CustomerRepo { get; private set; }

        public App(CustomerRepository repo)
        {
            InitializeComponent();
            CustomerRepo = repo;
            MainPage = new MainPage();
        }
    }
}