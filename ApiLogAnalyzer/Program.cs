
using ApiLogAnalyzer.Core;
using ApiLogAnalyzer.Repo;
using ApiLogAnalyzer.Shared;

UserSession session = new UserSession();
IApiLogRepository apiRepo = new ApiLogRepository(session);
IAppRunner appRunner = new AppRunner(apiRepo);


try
{
    appRunner.Run();
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}
