using DataExporter.Core;
using Serilog;

public class Program
{
    public static async Task Main(string[] args)
    {
        var log = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File("logs/leetcode-tracker.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        var notion = new Notion();
        var todoist = new Todoist();
        var database = new Database();
        var csv = new Export();

        log.Information("LeetCode Question Tracker service started.");

        if (!notion.IsDatabaseExists())
        {
            log.Error("Failed to find Notion database.");
            return;
        }

        await database.OpenConnection();

        var totalDbRecord = await database.CompareTotalQuestions();

        log.Information("Calculating Notion record ...");
        var totalNotionRecord = await notion.CountTotalRecord();
        
        log.Information($"Database Record = {totalDbRecord} ...");
        log.Information($"Notion Record = {totalNotionRecord} ...");


        if (totalDbRecord != totalNotionRecord)
        {
            var record = await database.SelectQuestions(totalDbRecord);
            var response = await notion.CreateNotionRecord(record);

            if (!response)
            {
                log.Error("Failed to insert data.");
                return;
            }

            log.Information("Data insert successfully.");

            await database.CloseConnection();

            var tasks = await todoist.GetAllTasks();
            var toReviseTask = await notion.FetchToReviseRecord();
            await todoist.CreateTask(toReviseTask);
        }

        log.Information("LeetCode Question Tracker service ended.");
    }
}