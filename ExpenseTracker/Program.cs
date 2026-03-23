using ExpenseTracker.Core;
using ExpenseTracker.Data;
using ExpenseTracker.Logging;
using ExpenseTracker.UI;

UIHandler uiHandler = new();
IExpenseRepository expenseRepo = new ExpenseRepository();
ILogKeeper logKeeper = new LogKeeper();
IExpenseService expenseService = new ExpenseService();
IUserService userService = new UserService();

IAppRunner app = new AppRunner(uiHandler, expenseService, userService);


try
{
    app.Run();
    
} catch (Exception ex)
{
    uiHandler.ShowGlobalErrorMsg();
    logKeeper.TakeEntry(ex);
}

public class UserService : IUserService
{
    public void EditProfile()
    {
        throw new NotImplementedException();
    }
}

public interface IUserService
{
    void EditProfile();
}

public class ExpenseService : IExpenseService
{
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

public interface IExpenseService
{
    void AddNewExpense();
    void SaveAndExit();
    void ShowTotalSummary();
    void ViewAllExpenses();
}