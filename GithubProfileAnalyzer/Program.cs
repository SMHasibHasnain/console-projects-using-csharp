using GithubProfileAnalyzer.Core;
using GithubProfileAnalyzer.Data;
using GithubProfileAnalyzer.Shared;
using GithubProfileAnalyzer.UI;

ICache cache = new Cache();

IUserInterface ui = new Cli();

using HttpClient client = new HttpClient();

IGithubApiClient apiClient = new GithubApiClient(client, cache);

IAppRunner app = new AppRunner(ui, apiClient);


try
{
    app.Run();
}
catch (Exception e)
{
    throw;
}
