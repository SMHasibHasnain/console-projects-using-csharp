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

    public List<Expense> getList()
    {
        var expenseListJson = File.ReadAllText(_expenseListFile);
        return JsonSerializer.Deserialize<List<Expense>>(expenseListJson)!;
    }
}
