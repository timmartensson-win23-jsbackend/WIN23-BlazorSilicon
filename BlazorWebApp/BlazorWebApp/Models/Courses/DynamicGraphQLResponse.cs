using System.Text.Json;
using System.Text.Json.Serialization;

namespace BlazorWebApp.Models.Courses;

public class DynamicGraphQLResponse
{
    [JsonPropertyName("data")]
    public JsonElement Data { get; set; }
}
