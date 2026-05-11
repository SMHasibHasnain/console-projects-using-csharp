
using ApiLogAnalyzer.Core;
using ApiLogAnalyzer.Repo;
using ApiLogAnalyzer.Service;
using ApiLogAnalyzer.Shared;
using ApiLogAnalyzer.Ui;

UserSession session = new UserSession();
Cli cli = new Cli(session);
IApiLogRepository apiRepo = new ApiLogRepository(session);
ISummery summery = new Summery(apiRepo, session);
IApiLogService apiLogService = new ApiLogService(session, apiRepo);
Menu menu = new Menu(session, cli, summery);
IAppRunner appRunner = new AppRunner(cli, session, menu, apiLogService);

try
{
    appRunner.Run();
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}
