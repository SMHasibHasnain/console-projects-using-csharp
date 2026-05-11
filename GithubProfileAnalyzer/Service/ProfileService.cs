using GithubProfileAnalyzer.Data;
using GithubProfileAnalyzer.Model;
using GithubProfileAnalyzer.Service;

namespace GithubProfileAnalyzer.Service;

public class ProfileService(IGithubApiClient apiClient) : IProfileService
{
    private IGithubApiClient _apiClient = apiClient;
    public async Task<User> GetUserProfile(string name, string url)
    {
        User user = await _apiClient.FetchAsync(name, url);


        return user;
    }
}