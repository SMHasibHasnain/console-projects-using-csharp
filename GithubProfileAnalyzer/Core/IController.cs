namespace GithubProfileAnalyzer.Core;

public interface IController
{
    public Dictionary<string, Func<(string name, List<string> list, int? value), Task>> Menu { get; set; }
    void MenuGenerator();
}
