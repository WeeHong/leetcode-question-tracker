using Newtonsoft.Json;

namespace DataExporter.Models.Notion;

public class Annotations
{
    [JsonProperty(PropertyName = "bold")]
    public bool? Bold { get; set; }

    [JsonProperty(PropertyName = "italic")]
    public bool? Italic { get; set; }

    [JsonProperty(PropertyName = "strikethrough")]
    public bool? Strikethrough { get; set; }

    [JsonProperty(PropertyName = "underline")]
    public bool? Underline { get; set; }

    [JsonProperty(PropertyName = "code")]
    public bool? Code { get; set; }

    [JsonProperty(PropertyName = "color")]
    public string? Color { get; set; }
}