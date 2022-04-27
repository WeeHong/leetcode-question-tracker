using DataExporter.Core;
using Serilog;

public class Program
{
    public static async Task Main(string[] args)
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        var log = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File("/temp/logs/leetcode-tracker.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();


        if (environment == null)
        {
            log.Error(".NET Core environment cannot be determined.");
            return;
        }

        var notion = new Notion(environment);
        var todoist = new Todoist(environment);
        var database = new Database();
        var csv = new Export();

        log.Information("LeetCode Question Tracker service started.");

        if (!notion.IsDatabaseExists())
        {
            log.Error("Failed to find Notion database.");
            return;
        }

        await database.OpenConnection();

        log.Information("Calculating Notion record.");
        await notion.RegisterRecord();

        var record = await database.fetchQuestions();
        var response = await notion.CreateNotionRecord(record);

        if (!response)
        {
            log.Error("Failed to insert data.");
            return;
        }

        log.Information("Question(s) insert successfully.");

        await database.CloseConnection();


        var tasks = await todoist.GetAllTasks();
        var toReviseTask = await notion.FetchToReviseRecord();

        log.Information("Creating Todoist task.");
        await todoist.CreateTask(toReviseTask);
        log.Information("Todoist task created successfully.");

        log.Information("LeetCode Question Tracker service ended.");
    }
}