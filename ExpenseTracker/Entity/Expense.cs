namespace ExpenseTracker.Entity;

public class Expense
{
    public string Id {get; } = Guid.CreateVersion7().ToString();
    public string? Title {get; private set;}
    public ExpenseCategory Category {get; private set;}
    public decimal Amount {get; private set;}

    public Expense(string title, ExpenseCategory expenseCategory, decimal amount)
    {
        Title = title;
        Category = expenseCategory;
        Amount = amount;
        Category = expenseCategory;
    }
}
