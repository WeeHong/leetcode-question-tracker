using System.Net.Http.Headers;
using System.Text;
using DataExporter.Models.Todoist;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

public class Todoist
{
    private readonly IConfiguration _configuration;
    private readonly string _token;

    private static HttpClient httpClient = new HttpClient();
    private static List<string> lookup = new();

    public Todoist()
    {
        _configuration = new ConfigurationBuilder()
                    .AddUserSecrets<Program>()
                    .Build();
        _token = _configuration["TodoistToken"];

        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
    }

    public async Task<List<string>> GetAllTasks()
    {
        var uri = new Uri($"https://api.todoist.com/rest/v1/tasks");
        var result = httpClient.GetAsync(uri).Result;

        var resultToString = await result.Content.ReadAsStringAsync();
        var tasks = JsonConvert.DeserializeObject<List<TodoistResponse>>(resultToString);

        if (tasks is not null)
        {
            foreach (var task in tasks!)
            {
                lookup.Add(task.Description!);
            }
            return lookup;
        }
        else
        {
            return new();
        }
    }

    public async Task CreateTask(IList<Result> tasks)
    {
        foreach (var task in tasks)
        {
            if (!lookup.Contains(task.Id))
            {
                var arguments = new Args()
                {
                    Id = "practice-leetcode",
                    Content = $"[{task.Properties.Name.Title[0].Text.Content}]({task.Url})",
                    Due = new Due()
                    {
                        Lang = "en",
                        IsRecurring = false,
                        String = "Every day",
                        Date = DateTime.UtcNow.AddDays(3).ToString("yyyy-MM-dd"),
                        Timezone = "Asia/Singapore"
                    },
                    DateAdded = DateTime.UtcNow.ToString("yyyy-MM-dd"),
                    Description = task.Id,
                    Priority = 1
                };

                var commands = new List<Command> {
                    new Command() {
                        Type = "item_add",
                        Uuid = Guid.NewGuid(),
                        TempId = "practice-leetcode-command",
                        Args = arguments
                    },
                    new Command() {
                        Type = "reminder_add",
                        Uuid = Guid.NewGuid(),
                        TempId = "practice-leetcode-reminder-temp-id",
                        Args = new Args() {
                            Type = "absolute",
                            ItemId = "practice-leetcode-command",
                            Due = new Due()
                            {
                                Lang = "en",
                                IsRecurring = false,
                                String = "Today at 20:00",
                                Date = DateTimeOffset.UtcNow.AddDays(3).ToString("yyyy-MM-dd") + "T08:00:00",
                                Timezone = "Asia/Singapore"
                            }
                        }
                    }
                };

                var taskInfo = new TodoistRequest()
                {
                    SyncToken = "*",
                    Commands = commands
                };
                var json = JsonConvert.SerializeObject(taskInfo);
                var payload = new StringContent(json, Encoding.UTF8, "application/json");
                var uri = new Uri($"https://api.todoist.com/sync/v8/sync");
                var result = await httpClient.PostAsync(uri, payload);
            }
        }
    }
}