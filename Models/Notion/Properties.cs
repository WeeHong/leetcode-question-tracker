namespace DataExporter.Models.Notion;

public partial class Properties
{
    public Tag Tag { get; set; } = new Tag();

    public Difficulty Difficulty { get; set; } = new Difficulty();

    public Progress Progress { get; set; } = new Progress();

    public No No { get; set; } = new No();

    public Name Name { get; set; } = new Name();
}