using Newtonsoft.Json;

namespace DataExporter.Models.Notion;

public partial class Tag
{
    [JsonProperty(PropertyName = "type")]
    public string? Type { get; set; }

    [JsonProperty(PropertyName = "multi_select")]
    public List<TagOptions>? MultiSelect { get; set; }
}

public class TagOptions
{
    [JsonProperty(PropertyName = "name")]
    public string? Name { get; set; }
}