using Newtonsoft.Json;

namespace DataExporter.Models.Notion;

public partial class Text
{
    [JsonProperty(PropertyName = "content")]
    public string? Content { get; set; }

    [JsonProperty(PropertyName = "link")]
    public Link? Link { get; set; }
}