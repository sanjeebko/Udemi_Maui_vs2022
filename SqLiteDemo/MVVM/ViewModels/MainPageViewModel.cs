using Bogus;
using SqLiteDemo.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SqLiteDemo.MVVM.ViewModels;

public class MainPageViewModel
{
    public List<Customer> Customers { get; set; }
    public Customer CurrentCustomer { get; set; }

    public ICommand AddOrUpdateCommand => new Command(() =>
    {
        //  App.CustomerRepo.AddOrUpdate(CurrentCustomer);
    });

    public MainPageViewModel()
    {
        GenerateNewCustomer();
    }

    private void GenerateNewCustomer()
    {
        CurrentCustomer = new Faker<Customer>()
            .RuleFor(x => x.Name, f => f.Person.FullName)
            .RuleFor(x => x.Address, f => f.Person.Address.Street)
            .Generate();
    }
}