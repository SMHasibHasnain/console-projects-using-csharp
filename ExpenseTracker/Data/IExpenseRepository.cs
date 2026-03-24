using ExpenseTracker.Entity;

namespace ExpenseTracker.Data;

public interface IExpenseRepository
{
    bool Exists();
    List<Expense> getList();
}
