namespace ExpenseTracker.Service;

using ExpenseTracker.Data;
using ExpenseTracker.Entity;
using ExpenseTracker.Shared;

public class ExpenseService : IExpenseService
{
    private readonly UserSession _userSession;
    private readonly IExpenseRepository _expenseRepo;
    public ExpenseService(IExpenseRepository expenseRepo, UserSession userSession)
    {
        _expenseRepo = expenseRepo;
        _userSession = userSession;
    }

    public bool TryLoadExpenseIntoSession()
    {
        if(!_expenseRepo.Exists() && _expenseRepo.GetList() == null) 
            return false;

        _userSession.ExpenseList = _expenseRepo.GetList();
        return true;    
    }

    public void AddNewExpense(Expense expenseDto)
    {
        //Validation here
        if(expenseDto == null) return;

        if(_userSession.ExpenseList == null)
        {
            _userSession.ExpenseList = new List<Expense>();
        }
        _userSession.ExpenseList.Add(expenseDto);  
    }

    public List<Expense> GetExpenseList()
    {
        throw new NotImplementedException();
    }

    public void TotalSummary()
    {
        throw new NotImplementedException();
    }

    public void Save()
    {
        _expenseRepo.Save(_userSession.ExpenseList);
    }

}
