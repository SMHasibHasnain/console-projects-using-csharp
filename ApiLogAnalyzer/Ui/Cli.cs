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

    public (string feature, int top) SelectXAndFeature()
    {
        string feature = AnsiConsole.Ask<string>("Feature: ");
        int top = AnsiConsole.Ask<int>("Top: ");
        return (feature, top);
    }

    public void AskForSelectMenu(Dictionary<string, Action> menuActions)
    {
        var size = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Choose one: ")
            .AddChoices(menuActions.Keys)
        );

        AnsiConsole.MarkupLine($"You selected: " + size);

        AnsiConsole.WriteLine("Click Any Key to Continue...");
        Console.ReadKey();
        Console.Clear();

        menuActions[size].Invoke();

    }
}