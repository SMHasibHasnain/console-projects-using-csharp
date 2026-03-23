namespace ExpenseTracker.Service;

using ExpenseTracker.Core;
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
}
