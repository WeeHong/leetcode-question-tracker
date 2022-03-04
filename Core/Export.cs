using System.Globalization;
using CsvHelper;
using Npgsql;

namespace DataExporter.Core;

public class Export
{
    private static StreamWriter writer = File.AppendText("questions.csv");
    private static CsvWriter _csv = new CsvWriter(writer, CultureInfo.InvariantCulture);

    public Export()
    {
    }

    public async Task ExportCsv(NpgsqlDataReader reader)
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

            _csv.Flush();
            _csv.WriteRecord(record);
            _csv.NextRecord();
        }
    }
}