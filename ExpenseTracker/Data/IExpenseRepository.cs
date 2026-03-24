using ExpenseTracker.Entity;

namespace ExpenseTracker.Data;

public interface IExpenseRepository
{
    bool Exists();
    List<Expense> GetList();
    void Save(List<Expense> expenseList);
}
