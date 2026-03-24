using ExpenseTracker.Core;
using ExpenseTracker.Data;
using ExpenseTracker.Entity;
using ExpenseTracker.Logging;
using ExpenseTracker.Service;
using ExpenseTracker.Shared;
using ExpenseTracker.UI;

UserSession userSession = new();
UIHandler uiHandler = new();
IExpenseRepository expenseRepo = new ExpenseRepository();
IUserRepository userRepo = new UserRepository();
ILogKeeper logKeeper = new LogKeeper();
IExpenseService expenseService = new ExpenseService(expenseRepo, userSession);
IUserService userService = new UserService(userRepo, userSession);

IAppInitializer appInitializer = new AppInitializer(uiHandler, 
    expenseService, userService, userSession);
IAppRunner app = new AppRunner(uiHandler, 
    expenseService, userService, userSession);

try
{
    appInitializer.Init();
    app.Run();
    
} catch (Exception ex)
{
    uiHandler.GlobalErrorMsg();
    logKeeper.TakeEntry(ex);
}
