namespace ExpenseTracker.Shared;

using ExpenseTracker.Entity;

public class UserSession
{
    public User CurrentUser {get; set;}
    public List<Expense> ExpenseList {get; set;}
}