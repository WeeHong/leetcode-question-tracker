using CsvHelper.Configuration.Attributes;

public class Question
{
    [Name("Question No")]
    public int QuestionNo { get; set; }
    public string? Title { get; set; }
    public string? Url { get; set; }
    public string? Difficulty { get; set; }
    public string? Tag { get; set; }
}