using ExpenseTracker.Entity;

namespace ExpenseTracker.Service;

public interface IExpenseService
{
    void AddNewExpense();
    List<Expense> GetExpenseList();
    void SaveAndExit();
    void ShowTotalSummary();
    void ViewAllExpenses();
}