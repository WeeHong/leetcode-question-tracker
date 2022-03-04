using Npgsql;

namespace DataExporter.Core;

public class Database
{
    private static NpgsqlConnection _connection = new NpgsqlConnection("Host=localhost; Username=admin; Password=password; Database=leetcode-question-db");

    public Database()
    {
    }

    public async Task<int> CompareTotalQuestions()
    {
        var cmd = new NpgsqlCommand("SELECT total FROM records ORDER BY created_at DESC FETCH FIRST ROW ONLY;", _connection);

        var result = await cmd.ExecuteReaderAsync();
        var totalRecords = 0;

        while (result.Read())
        {
            totalRecords = result.GetInt32(0);
        }

        result.Close();

        return totalRecords;
    }

    public async Task<NpgsqlDataReader> SelectQuestions(int total)
    {
        var cmd = new NpgsqlCommand($"SELECT questions_tags.question_id, questions.title, questions.slug, questions.difficulty, string_agg(tags.name, ', ') FROM questions_tags LEFT JOIN questions ON questions.id = questions_tags.question_id LEFT JOIN tags ON tags.id = questions_tags.tag_id GROUP BY questions_tags.question_id, questions.title, questions.slug, questions.difficulty OFFSET {total};", _connection);

        var result = await cmd.ExecuteReaderAsync();
        return result;
    }

    public async Task OpenConnection()
    {
        await _connection.OpenAsync();
    }

    public async Task CloseConnection()
    {
        await _connection.CloseAsync();
    }
}