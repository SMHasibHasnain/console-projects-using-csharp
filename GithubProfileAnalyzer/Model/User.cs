using System.Text.Json.Serialization;

namespace GithubProfileAnalyzer.Model;
public record User(
[property: JsonPropertyName("login")] string Login,
[property: JsonPropertyName("id")] int Id,
[property: JsonPropertyName("node_id")] string NodeId,
[property: JsonPropertyName("avatar_url")] string AvatarUrl,
[property: JsonPropertyName("gravatar_id")] string GravatarId,
[property: JsonPropertyName("url")] string Url,
[property: JsonPropertyName("html_url")] string HtmlUrl,
[property: JsonPropertyName("followers_url")] string FollowersUrl,
[property: JsonPropertyName("following_url")] string FollowingUrl,
[property: JsonPropertyName("gists_url")] string GistsUrl,
[property: JsonPropertyName("starred_url")] string StarredUrl,
[property: JsonPropertyName("subscriptions_url")] string SubscriptionsUrl,
[property: JsonPropertyName("organizations_url")] string OrganizationsUrl,
[property: JsonPropertyName("repos_url")] string ReposUrl,
[property: JsonPropertyName("events_url")] string EventsUrl,
[property: JsonPropertyName("received_events_url")] string ReceivedEventsUrl,
[property: JsonPropertyName("type")] string Type,
[property: JsonPropertyName("user_view_type")] string UserViewType,
[property: JsonPropertyName("site_admin")] bool SiteAdmin,
[property: JsonPropertyName("name")] string Name,
[property: JsonPropertyName("company")] object Company,
[property: JsonPropertyName("blog")] string Blog,
[property: JsonPropertyName("location")] object Location,
[property: JsonPropertyName("email")] object Email,
[property: JsonPropertyName("hireable")] object Hireable,
[property: JsonPropertyName("bio")] object Bio,
[property: JsonPropertyName("twitter_username")] object TwitterUsername,
[property: JsonPropertyName("public_repos")] int PublicRepos,
[property: JsonPropertyName("public_gists")] int PublicGists,
[property: JsonPropertyName("followers")] int Followers,
[property: JsonPropertyName("following")] int Following,
[property: JsonPropertyName("created_at")] DateTime CreatedAt,
[property: JsonPropertyName("updated_at")] DateTime UpdatedAt
);

