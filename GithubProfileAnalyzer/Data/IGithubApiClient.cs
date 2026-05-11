using GithubProfileAnalyzer.Model;

namespace GithubProfileAnalyzer.Data;

public interface IGithubApiClient
{
    Task<User> FetchAsync(string name, string url);
}
