using System.Text.Json;
using GithubProfileAnalyzer.Model;
using GithubProfileAnalyzer.Shared;

namespace GithubProfileAnalyzer.Data;

public class GithubApiClient(HttpClient client, ICache cache) : IGithubApiClient
{
    private readonly ICache _cache = cache;
    private readonly HttpClient _client = client;
    private readonly string _baseUrl = @"https://api.github.com/";

    public async Task<User> FetchAsync(string name, string url)
    {
        _client.BaseAddress = new Uri(_baseUrl);
        _client.DefaultRequestHeaders.Add("User-Agent", "GithubProfileAnalyzer");
        _client.DefaultRequestHeaders.Add("Accept", "application/vnd.github+json");
        HttpResponseMessage response = await _client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        System.Console.WriteLine(responseBody);
        var options = new JsonSerializerOptions{PropertyNameCaseInsensitive = true};
        User user = JsonSerializer.Deserialize<User>(responseBody, options);
        return user;
    }
}

