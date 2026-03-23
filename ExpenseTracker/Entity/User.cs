namespace ExpenseTracker.Entity;

public class User
{
    public string Id { get; } = Guid.CreateVersion7().ToString();
    public string Name {get; private set;}
    public DateOnly BirthDate {get; private set;}
    public decimal IncomePerMonth {get; private set;}

    public User(string name = "Guest User", decimal incomePerMonth = 0) 
    {
        Name = name;
        IncomePerMonth = incomePerMonth;
    }
}

