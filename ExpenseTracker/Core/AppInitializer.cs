namespace ExpenseTracker.Core;

using ExpenseTracker.Service;
using ExpenseTracker.Shared;
using ExpenseTracker.UI;

public class AppInitializer : IAppInitializer
{
    private readonly UIHandler _uiHandler;
    private readonly IExpenseService _expenseService;
    private readonly IUserService _userService;
    private readonly UserSession _userSession;

    public AppInitializer (UIHandler ui, IExpenseService expenseService, 
        IUserService userService, UserSession userSession)
    {
        _uiHandler = ui;
        _expenseService = expenseService;
        _userService = userService;
        _userSession = userSession;
    }

    public void Init()
    {
        if(_userService.DoesUserExist())
        {
            

        } else
        {
            
        }

        
    }
}
