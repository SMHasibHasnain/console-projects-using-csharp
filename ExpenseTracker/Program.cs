using ExpenseTracker.Core;
using ExpenseTracker.Data;
using ExpenseTracker.Logging;
using ExpenseTracker.UI;

UIHandler uiHandler = new();
IExpenseRepository expenseRepo = new ExpenseRepository();
ILogKeeper logKeeper = new LogKeeper();


IAppRunner app = new AppRunner(uiHandler, expenseRepo, logKeeper);


try
{
    app.Run();
    
} catch (Exception ex)
{
    uiHandler.ShowGlobalErrorMsg();
    logKeeper.TakeEntry(ex);
}


enum MenuItem
{
    AddNewExpense = 1,
    ViewAllExpenses,
    FilterbyCategory,
    ShowTotalSummary,
    SaveAndExit
}