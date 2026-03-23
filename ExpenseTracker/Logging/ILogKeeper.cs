namespace ExpenseTracker.Logging;

public interface ILogKeeper
{
    void TakeEntry(Exception ex);
}
