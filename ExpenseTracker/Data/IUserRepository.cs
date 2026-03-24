using ExpenseTracker.Entity;

namespace ExpenseTracker.Data;

public interface IUserRepository
{
    bool Exist();
    User Get();
}