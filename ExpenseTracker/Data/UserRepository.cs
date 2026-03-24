using System.Text.Json;
using ExpenseTracker.Entity;

namespace ExpenseTracker.Data;

public class UserRepository : IUserRepository
{
    private readonly string _userFile;

    public UserRepository(string userFile)
    {
        _userFile = userFile;
    }

    public bool Exist()
    {
        if(File.Exists(_userFile)) return true;
        return false;
    }

    public User Get()
    {
        var jsonData = File.ReadAllText(_userFile);
        var user = JsonSerializer.Deserialize<User>(jsonData);
        return user;
    }
}
