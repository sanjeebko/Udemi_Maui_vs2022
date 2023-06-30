using SQLite;
using SqLiteDemo.MVVM.Models;
using System.Linq.Expressions;

namespace SqLiteDemo.Repositories;

public class CustomerRepository
{
    private readonly SQLiteConnection _connection;
    public string StatusMessage { get; set; } = string.Empty;

    public CustomerRepository()
    {
        _connection = new SQLiteConnection(Constants.DatabasePath, Constants.FLAGS);
        _connection.CreateTable<Customer>();
    }

    public void Add(Customer customer)
    {
        try
        {
            int result = _connection.Insert(customer);
            StatusMessage = $"{result} row(s) added.";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Error: {ex.Message}";
        }
    }

    public void AddOrUpdate(Customer customer)
    {
        try
        {
            int result;
            if (customer.Id != 0)
            {
                result = _connection.Update(customer);
                StatusMessage = $"{result} row(s) updated.";
                return;
            }
            result = _connection.Insert(customer);
            StatusMessage = $"{result} row(s) added.";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Error: {ex.Message}";
        }
    }

    public List<Customer> GetAll()
    {
        try
        {
            return _connection.Table<Customer>().ToList();
        }
        catch (Exception ex)
        {
            StatusMessage = $"Error: {ex.Message}";
        }
        return new List<Customer>();
    }

    public List<Customer> GetAll(Expression<Func<Customer, bool>> predicate)
    {
        try
        {
            return _connection.Table<Customer>().Where(predicate).ToList();
        }
        catch (Exception ex)
        {
            StatusMessage = $"Error: {ex.Message}";
        }
        return new List<Customer>();
    }

    public Customer? Get(int id)
    {
        try
        {
            return _connection.Table<Customer>().FirstOrDefault(x => x.Id == id);
        }
        catch (Exception ex)
        {
            StatusMessage = $"Error: {ex.Message}";
        }
        return null;
    }

    public List<Customer> GetAll2()
    {
        try
        {
            return _connection.Query<Customer>("SELECT * FROM Customers").ToList();
        }
        catch (Exception ex)
        {
            StatusMessage = $"Error: {ex.Message}";
        }
        return new List<Customer>();
    }

    public void Delete(int customerId)
    {
        try
        {
            var customer = Get(customerId);
            _connection.Delete(customer);
        }
        catch (Exception ex)
        {
            StatusMessage = $"Error: {ex.Message}";
        }
    }
}