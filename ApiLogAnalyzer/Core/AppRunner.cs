using ApiLogAnalyzer.Repo;

namespace ApiLogAnalyzer.Core;

public class AppRunner : IAppRunner
{
    private readonly IApiLogRepository _apiRepo;

    public AppRunner(IApiLogRepository apiRepo)
    {
        _apiRepo = apiRepo;
    }

    public void Run()
    {
        _apiRepo.Load();
    }
}
