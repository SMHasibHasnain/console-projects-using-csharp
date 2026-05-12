using System.Text.Json;
using GithubProfileAnalyzer.Model;
using GithubProfileAnalyzer.Shared;

namespace GithubProfileAnalyzer.Data;

public class GithubApiClient : IGithubApiClient
{
    private readonly ICache _cache;
    private readonly HttpClient _client;
    private readonly string _baseUrl = @"https://api.github.com/";

    public GithubApiClient(HttpClient client, ICache cache)
    {
        _client = client;
        _cache = cache;
        _client.BaseAddress = new Uri(_baseUrl);
        _client.DefaultRequestHeaders.Add("User-Agent", "GithubProfileAnalyzer");
        _client.DefaultRequestHeaders.Add("Accept", "application/vnd.github+json");
    }

    public async Task<string> FetchAsync(string url)
    {
        HttpResponseMessage response = await _client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();    
    }

    public async Task<User> FetchProfileAsync(string url)
    {
        string responseBody = await FetchAsync(url);
        var options = new JsonSerializerOptions{PropertyNameCaseInsensitive = true};
        User user = JsonSerializer.Deserialize<User>(responseBody, options);
        return user;
    }

    public async Task<List<Follower>> FetchFollowersListAsync(string url)
    {
        string responseBody = await FetchAsync(url);
        var options = new JsonSerializerOptions{PropertyNameCaseInsensitive = true};
        List<Follower> list = JsonSerializer.Deserialize<List<Follower>>(responseBody, options);
        return list;
    }

}

