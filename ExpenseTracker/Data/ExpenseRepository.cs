using System.Text.Json;
using System.Text.Json.Nodes;
using ExpenseTracker.Entity;

namespace ExpenseTracker.Data;
public class ExpenseRepository : IExpenseRepository
{
    private readonly string _userDataDirectory;
    private readonly string _expenseListFile = "expenseList.json";
    private readonly string _filePath;
    public ExpenseRepository(string userDataDirectory)
    {
        _userDataDirectory = userDataDirectory;
        _filePath = Path.Combine(_userDataDirectory, _expenseListFile);
        if(!Directory.Exists(_userDataDirectory)) 
            Directory.CreateDirectory(_userDataDirectory);
    }

    public bool Exists()
    {
        if(File.Exists(_filePath)) return true;
        return false;
    }

    public List<Expense> GetList()
    {
        var expenseListJson = File.ReadAllText(_filePath);
        List<Expense> expense = JsonSerializer.Deserialize<List<Expense>>(expenseListJson)!;
        return expense;
    }

    public void Save(List<Expense> expenseList)
    {
        var expenseListJson = JsonSerializer.Serialize(expenseList);
        File.WriteAllText(_filePath, expenseListJson);
    }
}
