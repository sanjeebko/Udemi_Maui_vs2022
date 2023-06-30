using Bogus;
using PropertyChanged;
using SqLiteDemo.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SqLiteDemo.MVVM.ViewModels;

[AddINotifyPropertyChangedInterface]
public class MainPageViewModel
{
    public List<Customer> Customers { get; set; }
    public Customer CurrentCustomer { get; set; }

    public int TotalCustomers { get; set; } = 0;

    public ICommand AddOrUpdateCommand => new Command(() =>
    {
        App.CustomerRepo.AddOrUpdate(CurrentCustomer);
        Console.WriteLine(App.CustomerRepo.StatusMessage);
        GenerateNewCustomer();
        Refresh();
    });

    public ICommand DeleteCommand => new Command(() =>
    {
        if (CurrentCustomer.Id == 0)
            return;
        App.CustomerRepo.Delete(CurrentCustomer.Id);
        CurrentCustomer = null;
        Refresh();
    });

    public MainPageViewModel()
    {
        Refresh();
        GenerateNewCustomer();
    }

    private void GenerateNewCustomer()
    {
        CurrentCustomer = new Faker<Customer>()
            .RuleFor(x => x.Name, f => f.Person.FullName)
            .RuleFor(x => x.Address, f => f.Person.Address.Street)
            .Generate();
    }

    private void Refresh()
    {
        TotalCustomers = App.CustomerRepo.GetAll().Count();
        Customers = App.CustomerRepo.GetAll(x => x.Name.StartsWith("A"));
    }
}