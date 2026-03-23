using ExpenseTracker.Core;
using ExpenseTracker.Data;
using ExpenseTracker.Logging;
using ExpenseTracker.Service;
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
