namespace ExpenseTracker.Service;

using ExpenseTracker.Data;
using ExpenseTracker.Entity;
using ExpenseTracker.Shared;

public class UserService : IUserService
{
    private readonly UserSession _userSession;
    private readonly IUserRepository _userRepo;
    
    public UserService(IUserRepository userRepo, UserSession userSession)
    {
        _userRepo = userRepo;
        _userSession = userSession;
    }

    public void EditProfile()
    {
        throw new NotImplementedException();
    }

    public User GetUser()
    {
        throw new NotImplementedException();
    }

    public bool TryLoadUserIntoSession()
    {
        if( !_userRepo.Exist()) return false;

        var currUser = _userRepo.Get();
        if(currUser == null) return false;

        _userSession.CurrentUser = currUser;
        return true;
    }

    public bool TryRegisterAndLoadNewUser(string name, decimal incomePerMonth)
    {
        User user = new User(name, incomePerMonth);
        if(user == null) return false;
        _userSession.CurrentUser = user;
        return true;
    }
}
