namespace ExpenseTracker.Entity;

public class User
{
    public string Id { get; set;} = Guid.CreateVersion7().ToString();
    public string Name {get; set;}
    public DateOnly BirthDate {get; set;}
    public decimal IncomePerMonth {get; set;}

    public User(string name = "Guest User", decimal incomePerMonth = 0) 
    {
        Name = name;
        IncomePerMonth = incomePerMonth;
    }
}

