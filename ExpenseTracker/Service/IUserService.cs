namespace ExpenseTracker.Service;

public interface IUserService
{
    bool DoesUserExist();
    void EditProfile();
}
