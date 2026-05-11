using System.ComponentModel.Design;
using GithubProfileAnalyzer.UI;

namespace GithubProfileAnalyzer.Core;
public class AppRunner (IController controller, IUserInterface ui) : IAppRunner
{
    private IController _controller = controller;
    private IUserInterface _ui = ui;

    public async Task RunAsync()
    {
        _controller.MenuGenerator();

        while(true)
        {
            _ui.Welcome();
            (string nav, string name, List<string> list, int? value) inputPackage = _ui.ShowMenuTakeInput(_controller.Menu.Keys);
            
            if(_controller.Menu.Keys.
                Contains(inputPackage.nav))
            {
               await _controller.Menu[inputPackage.nav]((inputPackage.name, inputPackage.list, inputPackage.value));
            }

            System.Console.WriteLine("Tata from Run");
        }
    }
}
