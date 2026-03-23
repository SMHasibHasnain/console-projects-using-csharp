namespace ExpenseTracker.Service;

using ExpenseTracker.Core;
using ExpenseTracker.Shared;

public class ExpenseService : IExpenseService
{
    private readonly UserSession _userSession;
    public ExpenseService(UserSession userSession)
    {
        _userSession = userSession;
    }

    public void AddNewExpense()
    {
        throw new NotImplementedException();
    }

    public void SaveAndExit()
    {
        throw new NotImplementedException();
    }

    public void ShowTotalSummary()
    {
        throw new NotImplementedException();
    }

    public void ViewAllExpenses()
    {
        throw new NotImplementedException();
    }
}
