using ExpenseTracker.Core;
using ExpenseTracker.Data;
using ExpenseTracker.Entity;
using ExpenseTracker.Logging;
using ExpenseTracker.Service;
using ExpenseTracker.Shared;
using ExpenseTracker.UI;

var userFile = "user.json";
var expenseFile = "expenseList.json";
var logFile = "logs.txt";

UserSession userSession = new();
UIHandler uiHandler = new();
IExpenseRepository expenseRepo = new ExpenseRepository(expenseFile);
IUserRepository userRepo = new UserRepository(userFile);
ILogKeeper logKeeper = new LogKeeper(logFile);
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
    // uiHandler.GlobalErrorMsg();
    // logKeeper.TakeEntry(ex);
    throw;
}
