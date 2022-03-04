using Newtonsoft.Json;

namespace DataExporter.Models.Notion;

public class Progress
{
    [JsonProperty(PropertyName = "type")]
    public string? Type { get; set; }

    [JsonProperty(PropertyName = "select")]
    public ProgressOptions? Select { get; set; }
}

public class ProgressOptions
{
    [JsonProperty(PropertyName = "name")]
    public string? Name { get; set; }
}
