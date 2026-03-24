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
        if(!_expenseRepo.Exists() && _expenseRepo.getList() == null) 
            return false;

        _userSession.ExpenseList = _expenseRepo.getList();
        return true;    
    }

    public void AddNewExpense(Expense expenseDto)
    {
        //Validation here
        if(expenseDto == null) return;
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
        
    }

    public void SaveAndExit()
    {
        throw new NotImplementedException();
    }
}
