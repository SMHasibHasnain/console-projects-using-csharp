using GithubProfileAnalyzer.Model;

namespace GithubProfileAnalyzer.UI;

public interface IUserInterface
{
    public void HelpForMenuSelection(IEnumerable<string> values);
    (string nav, string name, List<string> list, int? value) ShowMenuTakeInput(IEnumerable<string> navs);
    public void ShowProfile(User user);
    void Welcome();
}