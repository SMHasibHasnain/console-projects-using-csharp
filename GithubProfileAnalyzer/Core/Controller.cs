using System.Dynamic;
using GithubProfileAnalyzer.Model;
using GithubProfileAnalyzer.Service;
using GithubProfileAnalyzer.UI;

namespace GithubProfileAnalyzer.Core;

public class Controller(IProfileService profileService, IRepositoryService repo, IUserInterface ui) : IController
{
    private readonly IProfileService _profileService = profileService;
    private readonly IRepositoryService _repoService = repo;
    private readonly IUserInterface _ui = ui;
    public Dictionary<string, Func<(string name, List<string> list, int? value), Task>> Menu { get; set; } = new();
    public void MenuGenerator(){
        Menu.Add("help", (inputPackage) =>
        {
            _ui.HelpForMenuSelection(Menu.Keys);
            return Task.CompletedTask;
        });

        Menu.Add("profile", async (inputPackage) =>
        {
            string url = $@"users/{inputPackage.name}";
            User user = await _profileService.GetUserProfile(url);
            _ui.ShowProfile(user);
        });
    }

}
