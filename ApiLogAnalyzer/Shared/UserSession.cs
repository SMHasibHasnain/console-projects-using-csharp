using ApiLogAnalyzer.Entity;

namespace ApiLogAnalyzer.Shared;

public class UserSession
{
    public List<string> ApiLogColumns { get; set; }
    public List<ApiLog> ApiLogDataList { get; set; }
    public UserSession()
    {
        ApiLogDataList = new List<ApiLog>();
        ApiLogColumns = new List<string>();
    }
}