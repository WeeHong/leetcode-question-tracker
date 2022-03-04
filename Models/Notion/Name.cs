using Newtonsoft.Json;

namespace DataExporter.Models.Notion;

public class Name
{
    [JsonProperty(PropertyName = "id")]
    public string? Id { get; set; }

    [JsonProperty(PropertyName = "type")]
    public string? Type { get; set; }

    [JsonProperty(PropertyName = "title")]
    public List<Title>? Title { get; set; }
}
