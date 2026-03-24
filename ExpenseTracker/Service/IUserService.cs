using ExpenseTracker.Entity;

namespace ExpenseTracker.Service;

public interface IUserService
{
    void EditProfile();
    User GetUser();
    bool TryRegisterAndLoadNewUser(User newUserDto);
    bool TryLoadUserIntoSession();
    void Save();
}
