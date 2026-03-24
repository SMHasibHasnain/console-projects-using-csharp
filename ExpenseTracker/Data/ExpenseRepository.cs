namespace ExpenseTracker.Data;
public class ExpenseRepository : IExpenseRepository
{
    private readonly string _expenseListFile;
    public ExpenseRepository(string expenseListFile)
    {
        _expenseListFile = expenseListFile;
    }
}
