using System;
using DataExporter.Models.Notion;
using Newtonsoft.Json;

namespace DataExporter.Models.Todoist;


public partial class FilterResponse
{
    [JsonProperty(PropertyName = "object")]
    public string? Object { get; set; }

    [JsonProperty(PropertyName = "results")]
    public List<Result> Results { get; set; } = new();

    [JsonProperty(PropertyName = "next_cursor")]
    public object? NextCursor { get; set; }

    [JsonProperty(PropertyName = "has_more")]
    public bool HasMore { get; set; }

    [JsonProperty(PropertyName = "type")]
    public string? Type { get; set; }
}

public partial class Result
{
    [JsonProperty(PropertyName = "object")]
    public string? Object { get; set; }

    [JsonProperty(PropertyName = "id")]
    public string Id { get; set; } = string.Empty;

    [JsonProperty(PropertyName = "created_time")]
    public DateTimeOffset CreatedTime { get; set; }

    [JsonProperty(PropertyName = "last_edited_time")]
    public DateTimeOffset LastEditedTime { get; set; }

    [JsonProperty(PropertyName = "created_by")]
    public TedBy? CreatedBy { get; set; }

    [JsonProperty(PropertyName = "last_edited_by")]
    public TedBy? LastEditedBy { get; set; }

    [JsonProperty(PropertyName = "cover")]
    public object? Cover { get; set; }

    [JsonProperty(PropertyName = "icon")]
    public object? Icon { get; set; }

    [JsonProperty(PropertyName = "parent")]
    public Parent? Parent { get; set; }

    [JsonProperty(PropertyName = "archived")]
    public bool Archived { get; set; }

    [JsonProperty(PropertyName = "properties")]
    public Properties Properties { get; set; } = new Properties();

    [JsonProperty(PropertyName = "url")]
    public Uri? Url { get; set; }
}

public partial class TedBy
{
    [JsonProperty(PropertyName = "object")]
    public string? Object { get; set; }

    [JsonProperty(PropertyName = "id")]
    public Guid Id { get; set; }
}

public partial class DateCompletion
{
    [JsonProperty(PropertyName = "id")]
    public string? Id { get; set; }

    [JsonProperty(PropertyName = "type")]
    public string? Type { get; set; }

    [JsonProperty(PropertyName = "date")]
    public Date? Date { get; set; }
}

public partial class Date
{
    [JsonProperty(PropertyName = "start")]
    public DateTimeOffset Start { get; set; }

    [JsonProperty(PropertyName = "end")]
    public object? End { get; set; }

    [JsonProperty(PropertyName = "time_zone")]
    public object? TimeZone { get; set; }
}

public partial class Select
{
    [JsonProperty(PropertyName = "id")]
    public Guid Id { get; set; }

    [JsonProperty(PropertyName = "name")]
    public string? Name { get; set; }

    [JsonProperty(PropertyName = "color")]
    public string? Color { get; set; }
}