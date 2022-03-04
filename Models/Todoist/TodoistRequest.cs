using Newtonsoft.Json;

namespace DataExporter.Models.Todoist;

public partial class TodoistRequest
{
    [JsonProperty(PropertyName = "sync_token")]
    public string? SyncToken { get; set; }

    [JsonProperty(PropertyName = "commands")]
    public List<Command>? Commands { get; set; }
}

public partial class Command
{
    [JsonProperty(PropertyName = "type")]
    public string? Type { get; set; }

    [JsonProperty(PropertyName = "uuid")]
    public Guid Uuid { get; set; }

    [JsonProperty(PropertyName = "temp_id")]
    public string? TempId { get; set; }

    [JsonProperty(PropertyName = "args")]
    public Args? Args { get; set; }
}

public partial class Args
{
    [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
    public string? Id { get; set; }

    [JsonProperty(PropertyName = "content", NullValueHandling = NullValueHandling.Ignore)]
    public string? Content { get; set; }

    [JsonProperty(PropertyName = "due")]
    public Due? Due { get; set; }

    [JsonProperty(PropertyName = "date_added", NullValueHandling = NullValueHandling.Ignore)]
    public string? DateAdded { get; set; }

    [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
    public string? Description { get; set; }

    [JsonProperty(PropertyName = "priority", NullValueHandling = NullValueHandling.Ignore)]
    public long? Priority { get; set; }

    [JsonProperty(PropertyName = "type", NullValueHandling = NullValueHandling.Ignore)]
    public string? Type { get; set; }

    [JsonProperty(PropertyName = "item_id", NullValueHandling = NullValueHandling.Ignore)]
    public string? ItemId { get; set; }
}

public partial class Due
{
    [JsonProperty(PropertyName = "lang")]
    public string? Lang { get; set; }

    [JsonProperty(PropertyName = "is_recurring")]
    public bool IsRecurring { get; set; }

    [JsonProperty(PropertyName = "string")]
    public string? String { get; set; }

    [JsonProperty(PropertyName = "date")]
    public string? Date { get; set; }

    [JsonProperty(PropertyName = "timezone")]
    public string? Timezone { get; set; }
}

public partial class Due
{
}