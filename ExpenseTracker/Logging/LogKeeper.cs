namespace ExpenseTracker.Logging;

public class LogKeeper : ILogKeeper
{
    private readonly string _logDirectory;
    private readonly string _logFile = $"log-{DateTime.Now:yyyy-MM-dd}.txt";
    public LogKeeper(string logDirectory)
    {
        _logDirectory = logDirectory;
        if(!Directory.Exists(_logDirectory)) 
            Directory.CreateDirectory(_logDirectory);
    }
    
    
    public void TakeEntry(Exception ex)
    {
        string filePath = Path.Combine(_logDirectory, _logFile);

        string msg = @$"
        -------------------------------------------------
        [ERROR] - {DateTime.Now}
        -------------------------------------------------
        {ex}
        -------------------------------------------------
        
        
        ";
        File.AppendAllText(filePath, msg);
    }
}
