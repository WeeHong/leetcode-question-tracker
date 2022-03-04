using DataExporter.Core;
using DataExporter.Models.Todoist;
using Newtonsoft.Json;

public class Program
{
    public static async Task Main(string[] args)
    {
        var notion = new Notion();
        var todoist = new Todoist();
        var database = new Database();
        var csv = new Export();

        // if (!notion.IsDatabaseExists())
        // {
        //     Console.WriteLine("Failed to find Notion database");
        //     return;
        // }

        // await database.OpenConnection();

        // var total = await database.CompareTotalQuestions();
        // var record = await database.SelectQuestions(total);
        // var response = await notion.CreateNotionRecord(record);

        // if (!response)
        // {
        //     Console.WriteLine("Failed to insert data");
        //     return;
        // }

        // Console.WriteLine("Data insert successfully");

        // await database.CloseConnection();

        var tasks = await todoist.GetAllTasks();
        var toReviseTask = await notion.FetchToReviseRecord();
        await todoist.CreateTask(toReviseTask);
    }
}