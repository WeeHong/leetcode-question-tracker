using Newtonsoft.Json;

namespace DataExporter.Models.Todoist;

public partial class FilterRequest
{
    [JsonProperty(PropertyName = "filter")]
    public Filter? Filter { get; set; }
}

public partial class Filter
{
    [JsonProperty(PropertyName = "and")]
    public List<And>? And { get; set; }
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