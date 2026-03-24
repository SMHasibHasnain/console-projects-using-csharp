using System.Text.Json;
using System.Text.Json.Nodes;
using ExpenseTracker.Entity;

namespace ExpenseTracker.Data;
public class ExpenseRepository : IExpenseRepository
{
    private readonly string _expenseListFile;
    public ExpenseRepository(string expenseListFile)
    {
        _expenseListFile = expenseListFile;
    }

    public bool Exists()
    {
        if(File.Exists(_expenseListFile)) return true;
        return false;
    }

    public List<Expense> GetList()
    {
        var expenseListJson = File.ReadAllText(_expenseListFile);
        List<Expense> expense = JsonSerializer.Deserialize<List<Expense>>(expenseListJson)!;
        return expense;
    }

    public void Save(List<Expense> expenseList)
    {
        var expenseListJson = JsonSerializer.Serialize(expenseList);
        File.WriteAllText(_expenseListFile, expenseListJson);
    }
}
