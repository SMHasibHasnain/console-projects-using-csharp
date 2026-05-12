using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Security;
using System.Reflection;
using System.Runtime;
using System.Security.AccessControl;
using GithubProfileAnalyzer.Model;
using Spectre.Console;
namespace GithubProfileAnalyzer.UI;

public class Cli : IUserInterface
{
    public void HelpForMenuSelection(IEnumerable<string> values)
    {
        
    }

    public (string nav, string name, List<string> list, int? value) ShowMenuTakeInput(IEnumerable<string> navs)
    {
        foreach (var item in navs)
        {
            System.Console.Write(item + " ");
            System.Console.WriteLine();
  
        }
        string name = Console.ReadLine().Trim();
        return ("profile", name!, null!, null);
    }

    public void ShowProfile(User user)
    {
        Type type = user.GetType();
        var properties = type.GetProperties();
        
        var table = new Table();

        table.AddColumn("Property");
        table.AddColumn("Value");

        foreach (var item in properties)
        {
            if( item.Name == "FollowingUrl" || item.Name ==  "GistsUrl" 
                || item.Name ==  "StarredUrl" || item.Name ==  "EventsUrl" 
                || item.Name ==  "Url" 
                || string.IsNullOrWhiteSpace(item.GetValue(user)?.ToString()))
            {
                continue;
            }

            table.AddRow(item.Name, item.GetValue(user)?.ToString() ?? "");
        }

        AnsiConsole.Write(table);

    }

    public void Welcome()
    {
        System.Console.WriteLine("hello!");
    }
}
