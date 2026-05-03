using ApiLogAnalyzer.Repo;
using ApiLogAnalyzer.Shared;
using ApiLogAnalyzer.Ui;
using ApiLogAnalyzer.Service;

namespace ApiLogAnalyzer.Core;

public class AppRunner : IAppRunner
{
    private readonly UserSession _session;
    private readonly Cli _cli;
    private readonly Menu _menu;
    private readonly IApiLogService _apiLogService;

    public AppRunner(Cli cli, UserSession session, Menu menu, IApiLogService apiLogService)
    {
        _session = session;
        _cli = cli;
        _menu = menu;
        _apiLogService = apiLogService;
        
    }
    
    public void Run()
    {

        _cli.ShowLoadingProgress("Loading API logs...", () =>
        {
            _apiLogService.Load();
        });

        _menu.MenuGenerator();

        _cli.AskForSelectMenu(_menu.MenuActions);
        

    }


}
