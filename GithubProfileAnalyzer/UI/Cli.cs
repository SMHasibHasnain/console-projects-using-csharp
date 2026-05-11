using System.Net.Security;
using System.Runtime;
using System.Security.AccessControl;
using GithubProfileAnalyzer.Model;
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
        System.Console.WriteLine(user.ToString());
    }

    public void Welcome()
    {
        System.Console.WriteLine("hello!");
    }
}
