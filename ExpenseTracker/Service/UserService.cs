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

    public void RegisterNewUser()
    {
        throw new NotImplementedException();
    }

    public bool TryLoadUserIntoSession()
    {
        if(_userRepo.Exist())
        {
            _userSession.CurrentUser = _userRepo.Get();
            return true;
        }
        
        return false;
    }
}
