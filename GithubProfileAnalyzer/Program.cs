using GithubProfileAnalyzer.Core;
using GithubProfileAnalyzer.Data;
using GithubProfileAnalyzer.Service;
using GithubProfileAnalyzer.Shared;
using GithubProfileAnalyzer.UI;

ICache cache = new Cache();

IUserInterface ui = new Cli();

using HttpClient client = new();

IGithubApiClient apiClient = new GithubApiClient(client, cache);

IProfileService profileService = new ProfileService();
IRepositoryService repositoryService = new RepositoryService();

IController controller = new Controller(profileService, repositoryService, ui);

IAppRunner app = new AppRunner(ui, apiClient);


try
{
    app.Run();
}
catch (Exception e)
{
    throw;
}
