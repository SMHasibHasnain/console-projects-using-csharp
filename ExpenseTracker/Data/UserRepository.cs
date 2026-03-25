using System.Text.Json;
using ExpenseTracker.Entity;

namespace ExpenseTracker.Data;

public class UserRepository : IUserRepository
{
    private readonly string _userDataDirectory;
    private readonly string _expenseListFile = "userInfo.json";
    private readonly string _filePath;
    public UserRepository(string userDataDirectory)
    {
        _userDataDirectory = userDataDirectory;
        _filePath = Path.Combine(_userDataDirectory, _expenseListFile);
        if(!Directory.Exists(_userDataDirectory)) 
            Directory.CreateDirectory(_userDataDirectory);
    }


    public bool Exist()
    {
        if(File.Exists(_filePath)) return true;
        return false;
    }

    public User Get()
    {
        var jsonData = File.ReadAllText(_filePath);
        var user = JsonSerializer.Deserialize<User>(jsonData);
        return user;
    }

    public void Save(User currentUser)
    {
        var userJson = JsonSerializer.Serialize(currentUser);
        File.WriteAllText(_filePath, userJson);
    }
}
