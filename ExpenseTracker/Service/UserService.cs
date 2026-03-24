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

    public void Save()
    {
        _userRepo.Save(_userSession.CurrentUser);
    }

    public bool TryLoadUserIntoSession()
    {
        if( !_userRepo.Exist()) return false;

        var currUser = _userRepo.Get();
        if(currUser == null) return false;

        _userSession.CurrentUser = currUser;
        return true;
    }

    public bool TryRegisterAndLoadNewUser(User newUserDto)
    {
        User user = newUserDto; //Validation is needed here, dto is replacable

        if(user == null) return false;
        _userSession.CurrentUser = user;
        return true;
    }
}
