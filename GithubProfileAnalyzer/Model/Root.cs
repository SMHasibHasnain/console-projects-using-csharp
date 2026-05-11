using System.Text.Json.Serialization;

namespace GithubProfileAnalyzer.Model;

public record Root(
    [property: JsonPropertyName("total_count")] int TotalCount,
    [property: JsonPropertyName("incomplete_results")] bool IncompleteResults,
    [property: JsonPropertyName("items")] IReadOnlyList<Item> Items
);

