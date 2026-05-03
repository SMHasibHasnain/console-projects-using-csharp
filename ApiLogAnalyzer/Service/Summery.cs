
using ApiLogAnalyzer.Repo;
using ApiLogAnalyzer.Shared;
using Microsoft.VisualBasic;

namespace ApiLogAnalyzer.Service;

public class Summery : ISummery
{
    private UserSession _session;
    private readonly IApiLogRepository _apiRepo;
    public Summery(IApiLogRepository apiRepo, UserSession userSession)
    {
        _apiRepo = apiRepo;
        _session = userSession;
    }

    public void Top(string feature, int topX)
    {
        var itemIndex = _session.ApiLogColumns.IndexOf(feature);

    }

    public static void Search()
    {

    }
}