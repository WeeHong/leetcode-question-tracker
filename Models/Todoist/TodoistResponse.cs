using Newtonsoft.Json;

namespace DataExporter.Models.Todoist;

public partial class TodoistResponse
{
    [JsonProperty(PropertyName = "id")]
    public long Id { get; set; }

    [JsonProperty(PropertyName = "assigner")]
    public long Assigner { get; set; }

    [JsonProperty(PropertyName = "project_id")]
    public long ProjectId { get; set; }

    [JsonProperty(PropertyName = "section_id")]
    public long SectionId { get; set; }

    [JsonProperty(PropertyName = "order")]
    public long Order { get; set; }

    [JsonProperty(PropertyName = "content")]
    public string? Content { get; set; }

    [JsonProperty(PropertyName = "description")]
    public string? Description { get; set; }

    [JsonProperty(PropertyName = "completed")]
    public bool Completed { get; set; }

    [JsonProperty(PropertyName = "label_ids")]
    public object[]? LabelIds { get; set; }

    [JsonProperty(PropertyName = "priority")]
    public long Priority { get; set; }

    [JsonProperty(PropertyName = "comment_count")]
    public long CommentCount { get; set; }

    [JsonProperty(PropertyName = "creator")]
    public long Creator { get; set; }

    [JsonProperty(PropertyName = "created")]
    public DateTimeOffset Created { get; set; }

    [JsonProperty(PropertyName = "due")]
    public Due? Due { get; set; }

    [JsonProperty(PropertyName = "url")]
    public Uri? Url { get; set; }
}
