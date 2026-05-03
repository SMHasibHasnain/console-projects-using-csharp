using ApiLogAnalyzer.Service;
using ApiLogAnalyzer.Shared;
using ApiLogAnalyzer.Ui;

namespace ApiLogAnalyzer.Core;

public class Menu
{
    private UserSession _session;
    private readonly Cli _cli;
    private readonly ISummery _summery;
    public Dictionary<string, Action> MenuActions = new();


    public Menu(UserSession session, Cli cli, ISummery summery)
    {
        _session = session;
        _cli = cli;
        _summery = summery;
    }

    public void MenuGenerator()
    {
        MenuActions.Add("Top x Features", () =>
        {
            var (feature, topX) = _cli.SelectXAndFeature();
            Summery.Top(feature, topX);
        });

        MenuActions.Add("Search by Feature", () => Summery.Search());

    }
}