namespace ExpenseTracker.Logging;

public class LogKeeper : ILogKeeper
{
    private readonly string _logFile;
    public LogKeeper(string logFile)
    {
        _logFile = logFile;
    }
    public void TakeEntry(Exception ex)
    {
        throw new NotImplementedException();
    }
}
