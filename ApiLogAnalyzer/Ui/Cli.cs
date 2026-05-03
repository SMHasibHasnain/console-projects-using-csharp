using System.ComponentModel.DataAnnotations.Schema;
using ApiLogAnalyzer.Shared;
using Spectre.Console;

namespace ApiLogAnalyzer.Ui;

public class Cli
{
    private UserSession _session;
    public Cli(UserSession session)
    {
        _session = session;
    }

    public void ShowLoadingProgress(string v, Action job)
    {
        AnsiConsole.Progress()
            .Start(ctx =>
            {
                var task = ctx.AddTask(v);
                job();
                task.Increment(100);
            });

        AnsiConsole.MarkupLine("[green]API logs loaded successfully![/]");
        AnsiConsole.WriteLine("Click Any Key to Continue...");
        Console.ReadKey();
        Console.Clear();    
    }
}