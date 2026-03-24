namespace ExpenseTracker.Service;

using ExpenseTracker.Data;
using ExpenseTracker.Entity;
using ExpenseTracker.Shared;

public class ExpenseService : IExpenseService
{
    private readonly UserSession _userSession;
    private readonly IExpenseRepository _expenseRepo;
    public ExpenseService(IExpenseRepository expenseRepo, UserSession userSession)
    {
        _expenseRepo = expenseRepo;
        _userSession = userSession;
    }

    public void AddNewExpense()
    {
        throw new NotImplementedException();
    }

    public List<Expense> GetExpenseList()
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

    public bool TryLoadExpenseIntoSession()
    {
        throw new NotImplementedException();
    }

    public void ViewAllExpenses()
    {
        throw new NotImplementedException();
    }
}
