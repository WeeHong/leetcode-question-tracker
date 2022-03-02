using System.Globalization;
using CsvHelper;
using Npgsql;

Console.WriteLine("Checking questions.csv exists ...");
if (File.Exists("questions.csv"))
{
    Console.WriteLine("questions.csv found.");
    File.Delete("questions.csv");
    Console.WriteLine("Deleted questions.csv.");
}

Console.WriteLine("Connecting to database ...");
var connectionString = "Host=localhost; Username=admin; Password=password; Database=leetcode-question-db";
await using var connection = new NpgsqlConnection(connectionString);
await connection.OpenAsync();

Console.WriteLine("Fetching record from database ...");
var cmd = new NpgsqlCommand("SELECT questions_tags.question_id, questions.title, questions.slug, questions.difficulty, string_agg(tags.name, ', ') FROM questions_tags LEFT JOIN questions ON questions.id = questions_tags.question_id LEFT JOIN tags ON tags.id = questions_tags.tag_id GROUP BY questions_tags.question_id, questions.title, questions.slug, questions.difficulty;", connection);

Console.WriteLine("Storing data to csv ...");
using (StreamWriter writer = File.AppendText("questions.csv"))
using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
{
    csv.WriteHeader<Question>();
    csv.NextRecord();

    await using (var reader = await cmd.ExecuteReaderAsync())
    {
        while (await reader.ReadAsync())
        {
            var record = new Question()
            {
                QuestionNo = reader.GetInt32(0),
                Title = reader.GetString(1),
                Url = $"https://leetcode.com/problems/{reader.GetString(2)}",
                Difficulty = reader.GetString(3),
                Tag = reader.GetString(4),
            };
            Console.WriteLine("Stored {0} to csv.", reader.GetString(1));

            csv.Flush();
            csv.WriteRecord(record);
            csv.NextRecord();
        }
    }
}

