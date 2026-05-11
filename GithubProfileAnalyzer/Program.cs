//Initialize

using GithubProfileAnalyzer.Data;
using GithubProfileAnalyzer.Shared;
using GithubProfileAnalyzer.UI;

ICache cache = new Cache();

IUserInterface ui = new Cli();

IGithubApiClient client = new GithubApiClient(cache);

