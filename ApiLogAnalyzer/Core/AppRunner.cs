using ApiLogAnalyzer.Repo;
using ApiLogAnalyzer.Shared;
using ApiLogAnalyzer.Ui;

namespace ApiLogAnalyzer.Core;

public class AppRunner : IAppRunner
{
    private readonly IApiLogRepository _apiRepo;
    private readonly UserSession _session;

    public AppRunner(IApiLogRepository apiRepo, UserSession session)
    {
        _apiRepo = apiRepo;
        _session = session;
    }

    public void Run()
    {
        _apiRepo.Load();
        var cli = new Cli(_session);
        cli.MakeApiDataList();






    }

}
