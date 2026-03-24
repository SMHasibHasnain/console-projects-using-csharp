using ExpenseTracker.Entity;

namespace ExpenseTracker.Service;

public interface IExpenseService
{
    void AddNewExpense(Expense expenseDto);
    List<Expense> GetExpenseList();
    void Save();
    void SaveAndExit();
    void TotalSummary();
    bool TryLoadExpenseIntoSession();
}