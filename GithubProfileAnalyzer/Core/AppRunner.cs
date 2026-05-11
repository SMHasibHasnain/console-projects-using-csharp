using GithubProfileAnalyzer.Data;
using GithubProfileAnalyzer.UI;

namespace GithubProfileAnalyzer.Core;
public class AppRunner (IController controller, IUserInterface ui) : IAppRunner
{
    private readonly IController _controller = controller;
    private readonly IUserInterface _ui = ui;

    public void Run()
    {
        
    }
}
