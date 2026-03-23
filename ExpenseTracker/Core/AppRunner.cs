using ExpenseTracker.UI;
using ExpenseTracker.Entity;
using ExpenseTracker.Service;
using ExpenseTracker.Shared;

namespace ExpenseTracker.Core;
public class AppRunner : IAppRunner
{
    private readonly UIHandler _uiHandler;
    private readonly IExpenseService _expenseService;
    private readonly IUserService _userService;
    private readonly UserSession _userSession;

    public AppRunner(UIHandler ui, IExpenseService expenseService, 
        IUserService userService, UserSession userSession)
    {
        _uiHandler = ui;
        _expenseService = expenseService;
        _userService = userService;
        _userSession = userSession;
    }
    
    public void Run()
    {
        var isRunning = true;

        while(isRunning)
        {
            _uiHandler.MenuHeading();
            _uiHandler.MenuList();
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
                _expenseService.AddNewExpense();
                break;

            case MenuItem.ShowTotalSummary:
                _expenseService.ShowTotalSummary();
                break;

            case MenuItem.ViewAllExpenses:
                _expenseService.ViewAllExpenses();
                break;    

            case MenuItem.EditProfile:
                _userService.EditProfile();
                break;

            case MenuItem.SaveAndExit:
                _expenseService.SaveAndExit();
                break;    

            default:
                _uiHandler.MenuDefaultCaseText();           
                break;    
        }
    }
}
