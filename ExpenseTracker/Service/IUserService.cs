using ExpenseTracker.Entity;

namespace ExpenseTracker.Service;

public interface IUserService
{
    bool DoesUserExist();
    void EditProfile();
    User GetUser();
    void RegisterNewUser();
}
