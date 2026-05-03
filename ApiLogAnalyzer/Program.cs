
using ApiLogAnalyzer.Core;
using ApiLogAnalyzer.Repo;
using ApiLogAnalyzer.Shared;
using ApiLogAnalyzer.Ui;

UserSession session = new UserSession();
Cli cli = new Cli(session);
IApiLogRepository apiRepo = new ApiLogRepository(session);
IAppRunner appRunner = new AppRunner(apiRepo, cli, session);



try
{
    appRunner.Run();
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}
