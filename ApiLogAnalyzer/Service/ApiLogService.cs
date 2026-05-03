using ApiLogAnalyzer.Repo;
using ApiLogAnalyzer.Shared;

namespace ApiLogAnalyzer.Service;

class ApiLogService : IApiLogService
{
    private UserSession _session;
    private readonly IApiLogRepository _apiRepo;
    public ApiLogService(UserSession session, IApiLogRepository repository)
    {
        _session = session;
        _apiRepo = repository;
    }

    public void Load()
    {
        _apiRepo.Load();
    }
}