using ExpenseTracker.Entity;

namespace ExpenseTracker.UI;

public class UIHandler
{
    public void GlobalErrorMsg()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nAn unexpected error occurred! Please check the logs or restart the app.");
        Console.ResetColor();
    }

    public void MenuHeading()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n==================================");
        Console.WriteLine("         EXPENSE TRACKER          ");
        Console.WriteLine("==================================");
        Console.ResetColor();
    }

    public void MenuList()
    {
        Console.WriteLine("\n1. Add New Expense");
        Console.WriteLine("2. Show Total Summary");
        Console.WriteLine("3. View All Expenses");
        Console.WriteLine("4. Edit Profile");
        Console.WriteLine("5. Save and Exit");
    }

    public bool TakeUserChoice(out int userChoice)
    {
        Console.Write("\nEnter your choice: ");
        string input = Console.ReadLine();
        return int.TryParse(input, out userChoice);
    }

    public void MenuDefaultCaseText()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nInvalid menu option! Please select a valid number from the list.");
        Console.ResetColor();
    }

    public void UserIncorrectChoiceText()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nInvalid input format! Please enter numbers only.");
        Console.ResetColor();
    }

    public void WelcomeBackMsg(string name)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nWelcome back, {name}!");
        Console.ResetColor();
    }

    public void WelcomeNewUser()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\nWelcome to Expense Tracker! Let's set up your profile.");
        Console.ResetColor();
    }

    public User AskUserForInfo()
    {
        Console.Write("Enter your name: ");
        String name = Console.ReadLine() ?? string.Empty;

        Console.Write("Enter your monthly income: ");

        decimal incomePerMonth;
        while (!decimal.TryParse(Console.ReadLine(), out incomePerMonth) || incomePerMonth < 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Invalid amount! Please enter a valid positive number: ");
            Console.ResetColor();
        }
        return new User(name, incomePerMonth);
    }

    public void RegistrationCompleteMsg(string currentUserName)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nRegistration successful! Profile created for {currentUserName}.");
        Console.ResetColor();
    }

    public void RegistrationFailedMsg()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nRegistration failed. Please provide valid information.");
        Console.ResetColor();
    }

    public void TryAgainMsg()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Please try again...");
        Console.ResetColor();
    }

    public Expense AskExpenseInfo()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n--- Enter Expense Details ---");
        Console.ResetColor();

        Console.Write("Enter a title for this expense (Optional): ");
        string title = Console.ReadLine() ?? string.Empty;
        

        decimal amount;
        Console.Write("Enter expense amount: ");
        while (!decimal.TryParse(Console.ReadLine(), out amount) || amount <= 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Invalid amount! Please enter a valid positive number: ");
            Console.ResetColor();
        }

        string category;
        Console.Write("Enter category (e.g., Food, Transport, Bills): ");
        while (string.IsNullOrWhiteSpace(category = Console.ReadLine()))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Category cannot be empty! Please enter a category: ");
            Console.ResetColor();
        }

        Console.Write("Enter a short note (optional): ");
        string note = Console.ReadLine() ?? string.Empty;

        return new Expense(title, category, amount, note);
    }

    public void ShowAllExpenses(IEnumerable<Expense> expenseList)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("--- All Expenses List --");
        Console.ResetColor();
        foreach(var item in expenseList)
        {
            Console.WriteLine($"{item.Title}  {item.Category}  {item.Amount}  {item.Note}");
        }
    }
}