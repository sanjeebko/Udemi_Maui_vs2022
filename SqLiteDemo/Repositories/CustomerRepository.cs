using SQLite;
using SqLiteDemo.MVVM.Models;

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
}