using Newtonsoft.Json;

namespace DataExporter.Models.Notion;

public class Page
{
    [JsonProperty(PropertyName = "parent")]
    public Parent? Parent { get; set; }

    [JsonProperty(PropertyName = "properties")]
    public Properties? Properties { get; set; }
}