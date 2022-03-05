using Newtonsoft.Json;

namespace DataExporter.Models.Todoist;

public partial class FilterRequest
{
    [JsonProperty(PropertyName = "filter")]
    public Filter? Filter { get; set; }

    [JsonProperty(PropertyName = "start_cursor", NullValueHandling = NullValueHandling.Ignore)]
    public string? StartCursor { get; set; }
}

public partial class Filter
{
    [JsonProperty(PropertyName = "and", NullValueHandling = NullValueHandling.Ignore)]
    public List<And>? And { get; set; }

    [JsonProperty(PropertyName = "property", NullValueHandling = NullValueHandling.Ignore)]
    public string? Property { get; set; }

    [JsonProperty(PropertyName = "rich_text", NullValueHandling = NullValueHandling.Ignore)]
    public RichText? RichText { get; set; }
}

public partial class And
{
    [JsonProperty(PropertyName = "property")]
    public string? Property { get; set; }

    [JsonProperty(PropertyName = "date", NullValueHandling = NullValueHandling.Ignore)]
    public Date? Date { get; set; }

    [JsonProperty(PropertyName = "select", NullValueHandling = NullValueHandling.Ignore)]
    public Select? Select { get; set; }
}

public partial class Date
{
    [JsonProperty(PropertyName = "is_not_empty")]
    public bool IsNotEmpty { get; set; }
}

public partial class Select
{
    [JsonProperty(PropertyName = "equals")]
    public string? SelectEquals { get; set; }
}

public partial class RichText
{
    [JsonProperty(PropertyName = "is_not_empty")]
    public bool? IsNotEmpty { get; set; }
}