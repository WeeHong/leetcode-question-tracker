using Newtonsoft.Json;

namespace DataExporter.Models.Notion;

public class No
{
    [JsonProperty(PropertyName = "type")]
    public string? Type { get; set; }

    [JsonProperty(PropertyName = "number")]
    public int Number { get; set; }
}