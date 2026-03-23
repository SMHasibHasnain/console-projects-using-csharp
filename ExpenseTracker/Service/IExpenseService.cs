namespace ExpenseTracker.Service;

public interface IExpenseService
{
    void AddNewExpense();
    void SaveAndExit();
    void ShowTotalSummary();
    void ViewAllExpenses();
}