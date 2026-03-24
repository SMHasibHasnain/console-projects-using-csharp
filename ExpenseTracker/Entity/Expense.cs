namespace ExpenseTracker.Entity;

public class Expense
{
    public string Id {get; } = Guid.CreateVersion7().ToString();
    public string? Title {get; private set;}
    public string Category {get; private set;}
    public decimal Amount {get; private set;}
    public DateTime DateTime {get; init;}
    public string Note { get; set; }

    public Expense(string title, string expenseCategory, decimal amount, string note)
    {
        Title = title;
        Category = expenseCategory;
        Amount = amount;
        DateTime = DateTime.Now;
        Note = note;
    }
}
