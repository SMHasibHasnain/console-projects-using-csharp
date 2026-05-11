using GithubProfileAnalyzer.Model;

namespace GithubProfileAnalyzer.Service;

public interface IProfileService
{
    User GetUserProfile(string name);
}