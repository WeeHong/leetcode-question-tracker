using System.Net.Http.Headers;
using System.Text;
using DataExporter.Models.Notion;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Npgsql;

namespace DataExporter.Core;

public class Notion
{
    private readonly IConfiguration _configuration;
    private readonly string _database;
    private readonly string _version;
    private readonly string _token;

    private static HttpClient httpClient = new HttpClient();

    public Notion()
    {
        _configuration = new ConfigurationBuilder()
            .AddUserSecrets<Program>()
            .Build();
        _database = _configuration["NotionDatabase"];
        _version = _configuration["NotionVersion"];
        _token = _configuration["NotionToken"];

        httpClient.DefaultRequestHeaders.Add("Notion-Version", _version);
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
    }

    public bool IsDatabaseExists()
    {
        var uri = new Uri($"https://api.notion.com/v1/databases/{_database}");
        var result = httpClient.GetAsync(uri).Result;

        return result.IsSuccessStatusCode;
    }

    public async Task<bool> CreateNotionRecord(NpgsqlDataReader reader)
    {
        bool isSuccess = true;
        while (await reader.ReadAsync())
        {
            List<TagOptions> tagOptions = new();
            HashSet<string> uniqueTags = new();

            var tags = reader.GetString(4).Split(",");
            foreach (var tag in tags)
            {
                uniqueTags.Add(tag.Trim());
            }

            foreach (var tag in uniqueTags)
            {
                tagOptions.Add(new TagOptions()
                {
                    Name = tag
                });
            }

            List<Title> titles = new();
            titles.Add(new Title()
            {
                Type = "text",
                Text = new Text()
                {
                    Content = reader.GetString(1),
                    Link = new Link()
                    {
                        Url = new Uri($"https://leetcode.com/problems/{reader.GetString(2)}")
                    }
                },
                Annotations = new Annotations
                {
                    Bold = false,
                    Italic = false,
                    Strikethrough = false,
                    Underline = false,
                    Code = false,
                    Color = "default"
                },
                PlainText = reader.GetString(1),
                Href = $"https://leetcode.com/problems/{reader.GetString(2)}",
            });

            var pageData = new Page()
            {
                Parent = new Parent()
                {
                    DatabaseId = _database
                },
                Properties = new Properties()
                {
                    Tag = new Tag()
                    {
                        Type = "multi_select",
                        MultiSelect = tagOptions
                    },
                    Difficulty = new Difficulty()
                    {
                        Type = "select",
                        Select = new DifficultyOptions
                        {
                            Name = reader.GetString(3)
                        }
                    },
                    Progress = new Progress()
                    {
                        Type = "select",
                        Select = null
                    },
                    No = new No()
                    {
                        Type = "number",
                        Number = reader.GetInt32(0),
                    },
                    Name = new Name()
                    {
                        Id = "title",
                        Type = "title",
                        Title = titles
                    }
                }
            };

            var createPageUri = new Uri("https://api.notion.com/v1/pages");
            var json = JsonConvert.SerializeObject(pageData);
            var payload = new StringContent(json, Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync(createPageUri, payload);

            isSuccess = response.Result.IsSuccessStatusCode;

            if (!isSuccess)
                break;

            Console.WriteLine($"Question #{reader.GetInt32(0)} insert succesfully.");
        }
        return await Task.FromResult(isSuccess);
    }
}