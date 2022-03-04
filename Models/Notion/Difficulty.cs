using Newtonsoft.Json;

namespace DataExporter.Models.Notion;

public class Difficulty
{
    [JsonProperty(PropertyName = "type")]
    public string? Type { get; set; }

    [JsonProperty(PropertyName = "select")]
    public DifficultyOptions? Select { get; set; }
}

public class DifficultyOptions
{
    [JsonProperty(PropertyName = "name")]
    public string? Name { get; set; }
}
