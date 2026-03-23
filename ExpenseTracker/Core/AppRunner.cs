using ExpenseTracker.Data;
using ExpenseTracker.Logging;
using ExpenseTracker.UI;

namespace ExpenseTracker.Core;
public class AppRunner : IAppRunner
{
    private readonly UIHandler _uiHandler;
    private readonly IExpenseRepository _expenseRepo; 
    private readonly ILogKeeper _logkeeper; 
    public AppRunner(UIHandler ui, IExpenseRepository expenseRepo, ILogKeeper logkeeper)
    {
        _uiHandler = ui;
        _expenseRepo = expenseRepo;
        _logkeeper = logkeeper;
    }
    
    public void Run()
    {
        var isRunning = true;
        while(isRunning)
        {
            _uiHandler.ShowMenuHeading();
            _uiHandler.ShowMenuList();
            if(_uiHandler.TakeUserChoice(out int userChoice)) ProcessUserChoice(userChoice);
            else
            {
                _uiHandler.UserIncorrectChoiceText();
                continue;
            }
        }
        
    }

    private void ProcessUserChoice(int userChoice)
    {
        var menuSelected = (MenuItem) userChoice;
        switch(menuSelected)
        {
            case MenuItem.AddNewExpense:
                
                break;
            case MenuItem.FilterbyCategory:

                break;

            case MenuItem.SaveAndExit:

                break;

            case MenuItem.ShowTotalSummary:

                break;

            case MenuItem.ViewAllExpenses:

                break;

            case 0:

                _uiHandler.MenuDefaultCaseText();           
                break;    
        }
    }
}
