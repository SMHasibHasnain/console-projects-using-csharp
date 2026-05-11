using GithubProfileAnalyzer.Model;

namespace GithubProfileAnalyzer.Service;

public interface IProfileService
{
    Task<User> GetUserProfile(string name, string url);
}