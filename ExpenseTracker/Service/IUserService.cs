using ExpenseTracker.Entity;

namespace ExpenseTracker.Service;

public interface IUserService
{
    void EditProfile();
    User GetUser();
    bool TryRegisterAndLoadNewUser(string name, decimal incomePerMonth);
    bool TryLoadUserIntoSession();
}
