namespace ExpenseTracker.Entity;

public class Expense
{
    public string Id {get; set;} = Guid.CreateVersion7().ToString();
    public string? Title {get; set;}
    public string Category {get; set;}
    public decimal Amount {get; set;}
    public DateTime DateTime {get; init;}
    public string Note { get; set; }

    public Expense() {}
    public Expense(string title, string expenseCategory, decimal amount, string note)
    {
        Title = title;
        Category = expenseCategory;
        Amount = amount;
        DateTime = DateTime.Now;
        Note = note;
    }
}
