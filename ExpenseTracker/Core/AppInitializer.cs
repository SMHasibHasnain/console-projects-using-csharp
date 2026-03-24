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
        if(_userService.TryLoadUserIntoSession())
        {
            _uiHandler.WelcomeBackMsg( _userSession
                .CurrentUser.Name); 
            _expenseService.TryLoadExpenseIntoSession();    

        } else
        {
            bool isRegistered = false;
            _uiHandler.WelcomeNewUser();
            while(!isRegistered)
            {
                _uiHandler.AskUserForInfo(out string name, out decimal incomePerMonth);
                var isValid = _userService.TryRegisterAndLoadNewUser(name, incomePerMonth);
                if(isValid)
                {
                    _uiHandler.RegistrationCompleteMsg(_userSession.CurrentUser.Name);
                    isRegistered = true;
                }
                else
                {
                    _uiHandler.RegistrationFailedMsg();
                    _uiHandler.TryAgainMsg();
                }
            }
        }
    }
}
