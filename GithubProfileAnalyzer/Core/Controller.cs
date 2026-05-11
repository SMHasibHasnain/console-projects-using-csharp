using GithubProfileAnalyzer.Model;
using GithubProfileAnalyzer.Service;
using GithubProfileAnalyzer.UI;

namespace GithubProfileAnalyzer.Core;

public class Controller(IProfileService profileService, IRepositoryService repo, IUserInterface ui) : IController
{
    private readonly IProfileService _profileService = profileService;
    private readonly IRepositoryService _repoService = repo;
    private readonly IUserInterface _ui = ui;
    public Dictionary<string, Action<string, List<string>, int?>> Menu = [];

    public void MenuGenerator()
    {
        Menu.Add("help", (name, list, value) =>
        {
            _ui.HelpForMenuSelection(Menu.Keys);
        });

        Menu.Add("profile", (name, list, value) =>
        {
            User user = _profileService.GetUserProfile(name);
            _ui.ShowProfile(user);
        });
    }
}
