using Newtonsoft.Json;

namespace DataExporter.Models.Notion;

public partial class Title
{
    [JsonProperty(PropertyName = "type")]
    public string? Type { get; set; }

    [JsonProperty(PropertyName = "text")]
    public Text Text { get; set; } = new Text();

    [JsonProperty(PropertyName = "annotations")]
    public Annotations? Annotations { get; set; }

    [JsonProperty(PropertyName = "plain_text")]
    public string? PlainText { get; set; }

    [JsonProperty(PropertyName = "href")]
    public string? Href { get; set; }
}