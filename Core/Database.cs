using Npgsql;

namespace DataExporter.Core;

public class Database
{
    private static NpgsqlConnection _connection = new NpgsqlConnection("Host=db-postgresql-sgp1-08533-do-user-2861313-0.b.db.ondigitalocean.com; Port=25060; Username=doadmin; Password=R06KhWsuOxTGR1n9; Database=leetcodedb");

    public Database()
    {
    }

    public async Task<NpgsqlDataReader> fetchQuestions()
    {
        var cmd = new NpgsqlCommand($"SELECT questions_tags.question_id, questions.title, questions.slug, questions.difficulty, string_agg(tags.name, ', ') FROM questions_tags LEFT JOIN questions ON questions.id = questions_tags.question_id LEFT JOIN tags ON tags.id = questions_tags.tag_id GROUP BY questions_tags.question_id, questions.title, questions.slug, questions.difficulty;", _connection);

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