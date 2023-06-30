using RestDemo.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RestDemo.MVVM.ViewModels;

public class MainViewModel
{
    public HttpClient client;
    private JsonSerializerOptions _serializerOptions;
    private string baseUrl = "https://649df85b9bac4a8e669e7d37.mockapi.io";

    private List<User> _users = new List<User>();

    public MainViewModel()
    {
        client = new HttpClient();
        _serializerOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
        };
    }

    public ICommand GetAllUsersCommand => new Command(async () =>
    {
        var url = $"{baseUrl}/users";
        var response = await client.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            using (var responseStream = await response.Content.ReadAsStreamAsync())
            {
                var data = await JsonSerializer.DeserializeAsync<List<User>>(responseStream, _serializerOptions);
                _users = data;
            }
        }
    });

    public ICommand GetSingleUserCommand => new Command(async () =>
    {
        var url = $"{baseUrl}/users/25";
        var response = await client.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            using (var responseStream = await response.Content.ReadAsStreamAsync())
            {
                var data = await JsonSerializer.DeserializeAsync<User>(responseStream, _serializerOptions);
            }
        }
    });

    public ICommand AddUserCommand => new Command(async () =>
    {
        var url = $"{baseUrl}/users";
        var user = new User
        {
            createdAt = DateTime.Now,
            name = "Sanjeeb",
            avatar = "https://fakeimg.pl/350x200/?text=MAUI"
        };
        string json = JsonSerializer.Serialize<User>(user, _serializerOptions);
        StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await client.PostAsync(url, content);

        if (response.IsSuccessStatusCode)
        {
        }
    });

    public ICommand UpdateUserCommand => new Command(async () =>
    {
        var url = $"{baseUrl}/users/1";
        var user = _users.FirstOrDefault(a => a.id == "1");
        user.name = "Pappu";
        string json = JsonSerializer.Serialize<User>(user, _serializerOptions);
        StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await client.PutAsync(url, content);

        if (response.IsSuccessStatusCode)
        {
        }
    });

    public ICommand DeleteUserCommand => new Command(async () =>
    {
        var url = $"{baseUrl}/users/1";

        var response = await client.DeleteAsync(url);

        if (response.IsSuccessStatusCode)
        {
        }
    });
}