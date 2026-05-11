using GithubProfileAnalyzer.Model;

namespace GithubProfileAnalyzer.UI;

public interface IUserInterface
{
    public void HelpForMenuSelection(IEnumerable<string> values);
    public void ShowProfile(User user);
}