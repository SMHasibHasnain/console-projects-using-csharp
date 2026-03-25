using ExpenseTracker.Core;
using ExpenseTracker.Data;
using ExpenseTracker.Entity;
using ExpenseTracker.Logging;
using ExpenseTracker.Service;
using ExpenseTracker.Shared;
using ExpenseTracker.UI;

var userDataDirectory = "_userData";
var logDirectory = "_logs";

UserSession userSession = new();
UIHandler uiHandler = new();
IExpenseRepository expenseRepo = new ExpenseRepository(userDataDirectory);
IUserRepository userRepo = new UserRepository(userDataDirectory);
ILogKeeper logKeeper = new LogKeeper(logDirectory);
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
    throw;
}
