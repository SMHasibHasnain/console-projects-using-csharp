using GithubProfileAnalyzer.Core;
using GithubProfileAnalyzer.Data;
using GithubProfileAnalyzer.Service;
using GithubProfileAnalyzer.Shared;
using GithubProfileAnalyzer.UI;

ICache cache = new Cache();

IUserInterface ui = new Cli();

using HttpClient httpClient = new();

IGithubApiClient apiClient = new GithubApiClient(httpClient, cache);

IProfileService profileService = new ProfileService(apiClient);
IRepositoryService repositoryService = new RepositoryService();

IController controller = new Controller(profileService, repositoryService, ui);
IAppRunner app = new AppRunner(controller, ui);


try
{
    app.Run();
}
catch (Exception e)
{
    throw;
}
