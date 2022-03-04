using Newtonsoft.Json;

namespace DataExporter.Models.Notion;

public partial class Parent
{
    [JsonProperty(PropertyName = "database_id")]
    public string? DatabaseId { get; set; }
}













