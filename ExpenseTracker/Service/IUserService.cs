using ExpenseTracker.Entity;

namespace ExpenseTracker.Service;

public interface IUserService
{
    void EditProfile();
    User GetUser();
    void RegisterNewUser();
    bool TryLoadUserIntoSession();
}
