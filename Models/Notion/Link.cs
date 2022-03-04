using Newtonsoft.Json;

namespace DataExporter.Models.Notion;

public class Link
{
    [JsonProperty(PropertyName = "url")]
    public Uri? Url { get; set; }
}