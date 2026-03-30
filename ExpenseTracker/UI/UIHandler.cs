using ExpenseTracker.Entity;

namespace ExpenseTracker.UI;

public class UIHandler
{
    public void Heading(string text)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(text);
        Console.WriteLine("==================================" + Environment.NewLine);
        Console.ResetColor();
    }

    public void ErrorMsg(string text)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(text);
        Console.ResetColor();        
    }

    public void GlobalErrorMsg()
    {
        ErrorMsg("An unexpected error occurred! Please check the logs or restart the app.");
    }

    public void MenuHeading()
    {
        Heading("EXPENSE TRACKER");
    }

    public void MenuList()
    {
        Console.WriteLine("1. Add New Expense");
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
        ErrorMsg("Invalid menu option! Please select a valid number from the list.");
    }

    public void UserIncorrectChoiceText()
    {
        ErrorMsg("Invalid input format! Please enter numbers only.");
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
        ErrorMsg("Please try again...");
    }

    public Expense AskExpenseInfo()
    {
        Heading("ADD EXPENSE DETAILS");

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
        Heading("ALL EXPENSES LIST");
        foreach(var item in expenseList)
        {
            Console.WriteLine($"{item.Title}  {item.Category}  {item.Amount}  {item.Note}");
        }
    }

    public void ShowSummary(int listLength, int uniqueCategoryCount)
    {
        Heading("EXPENSE SUMMARY");
        Console.WriteLine($"Total Expenses Recorded : {listLength}");
        Console.WriteLine($"Categories Used         : {uniqueCategoryCount}");

        if (listLength == 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nYou haven't added any expenses yet.");
            Console.ResetColor();
        }
        Console.WriteLine();
    }
}