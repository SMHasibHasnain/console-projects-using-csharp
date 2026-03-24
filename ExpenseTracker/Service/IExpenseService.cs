using ExpenseTracker.Entity;

namespace ExpenseTracker.Service;

public interface IExpenseService
{
    void AddNewExpense(Expense expenseDto);
    List<Expense> GetExpenseList();
    void Save();
    int ListLength();
    bool TryLoadExpenseIntoSession();
    string[] UniqueCategoryList();
    int UniqueCategoryCount();
}