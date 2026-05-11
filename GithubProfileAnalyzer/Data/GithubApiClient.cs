using GithubProfileAnalyzer.Shared;

namespace GithubProfileAnalyzer.Data;

public class GithubApiClient(ICache cache) : IGithubApiClient
{
    private readonly ICache _cache = cache;
}
