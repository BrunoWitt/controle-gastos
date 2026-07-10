using Npgsql;
using Src.Shared.Database;

namespace Src.Shared.Base;

public abstract class BaseRepository<TEntity>
    where TEntity : BaseModel
{
    protected virtual string TableName => typeof(TEntity).Name.ToLower();

    protected abstract TEntity Map(NpgsqlDataReader reader);


    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        var query = $"SELECT * FROM {TableName}";

        var list = new List<TEntity>();

        await using var conn = DatabaseConnection.GetConnection();

        await conn.OpenAsync();

        await using var cmd = new NpgsqlCommand(query, conn);

        await using var reader = await cmd.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            list.Add(Map(reader));
        }

        return list;
    }


    protected async Task<int> ExecuteAsync(
        string query,
        Action<NpgsqlCommand> parameters)
    {
        await using var conn = DatabaseConnection.GetConnection();

        await conn.OpenAsync();

        await using var cmd = new NpgsqlCommand(query, conn);

        parameters(cmd);

        return await cmd.ExecuteNonQueryAsync();
    }


    protected async Task<int> ExecuteScalarAsync(
        string query,
        Action<NpgsqlCommand> parameters)
    {
        await using var conn = DatabaseConnection.GetConnection();

        await conn.OpenAsync();

        await using var cmd = new NpgsqlCommand(query, conn);

        parameters(cmd);

        var result = await cmd.ExecuteScalarAsync();

        return Convert.ToInt32(result);
    }


    public abstract Task<int> CreateAsync(TEntity entity);

    public abstract Task<bool> UpdateAsync(TEntity entity);

    public async Task<bool> DeleteAsync(int id)
    {
        var query = $"""
            DELETE FROM {TableName}
            WHERE id = @id;
            """;

        var result = await ExecuteAsync(query, cmd =>
        {
            cmd.Parameters.AddWithValue("@id", id);
        });

        return result > 0;
    }
}