namespace ExpenseTracker.Service;

using System.Linq.Expressions;
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

    public int ListLength()
    {
        return _userSession.ExpenseList.Count();
    }

    public void Save()
    {
        _expenseRepo.Save(_userSession.ExpenseList);
    }

    public string[] UniqueCategoryList()
    {
        string[] categoryList = CategoryList();
        int categoryListSize = categoryList.Length;
        int ptr = 0;

        string[] uniqueCategoryList = new string[categoryListSize]; 
        int uniqueCount = 0;

        for(int i=0; i<categoryListSize; i++)
        {
            if(uniqueCategoryList.Length == 0) uniqueCategoryList[uniqueCount++] = categoryList[ptr++];
            for(int j=0; j<uniqueCount; j++)
            {
                if(categoryList[i] != uniqueCategoryList[j]) continue;
                uniqueCategoryList[j] = categoryList[i];
                uniqueCount++;
            }
        }

        Array.Resize(ref uniqueCategoryList, uniqueCount);

        return uniqueCategoryList;

    }

    public int UniqueCategoryCount()
    {
        return UniqueCategoryList().Length;
    }

    private string[] CategoryList()
    {
        int count = 0;
        string[] arr = new string[_userSession.ExpenseList.Count];
        foreach(var item in _userSession.ExpenseList)
        {
            arr[count++] = item.Category;
        }
        return arr;
    }

}
