namespace ExpenseTracker.Service;

using ExpenseTracker.Entity;
using ExpenseTracker.Shared;

public class UserService : IUserService
{
    private readonly UserSession _userSession;
    
    public UserService(UserSession userSession)
    {
        _userSession = userSession;
    }

    public bool DoesUserExist()
    {
        throw new NotImplementedException();
    }

    public void EditProfile()
    {
        throw new NotImplementedException();
    }

    public User GetUser()
    {
        throw new NotImplementedException();
    }

    public void RegisterNewUser()
    {
        throw new NotImplementedException();
    }
}
