using GithubProfileAnalyzer.Data;
using GithubProfileAnalyzer.Model;
using GithubProfileAnalyzer.Service;

namespace GithubProfileAnalyzer.Service;

public class ProfileService(IGithubApiClient apiClient) : IProfileService
{
    private IGithubApiClient _apiClient = apiClient;
    public async Task<User> GetUserProfile(string url)
    {
        User user = await _apiClient.FetchProfileAsync(url);

        List<Follower> followers = await _apiClient.FetchFollowersListAsync(url + @"/followers");

        string strings = string.Join(", ", followers.Select(f => f.Login));

        User updatedUser = user with {FollowersUrl = strings};

        return updatedUser;
    }
}