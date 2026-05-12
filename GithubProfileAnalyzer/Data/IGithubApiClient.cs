using GithubProfileAnalyzer.Model;

namespace GithubProfileAnalyzer.Data;

public interface IGithubApiClient
{
    Task<string> FetchAsync(string url);
    Task<User> FetchProfileAsync(string url);
    Task<List<Follower>> FetchFollowersListAsync(string url);
}
