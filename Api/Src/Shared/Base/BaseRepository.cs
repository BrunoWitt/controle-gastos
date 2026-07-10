using Npgsql;
using System.Reflection;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Shared.Base;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
    where TEntity : BaseModel, new()
{

    private readonly IConfiguration _configuration;

    protected BaseRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected NpgsqlConnection Connection =>
        new(_configuration.GetConnectionString("Default"));

    protected virtual string TableName =>
        typeof(TEntity).Name.ToLower();

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        var result = new List<TEntity>();

        var sql = $"SELECT * FROM {TableName}";

        using var connection = Connection;

        await connection.OpenAsync();

        using var command = new NpgsqlCommand(sql, connection);

        using var reader = await command.ExecuteReaderAsync();

        while(await reader.ReadAsync())
        {
            result.Add(Map(reader));
        }

        return result;
    }


    public async Task CreateAsync(TEntity entity)
    {
        var properties = typeof(TEntity)
            .GetProperties()
            .Where(x => x.Name != "Id");

        var columns = string.Join(", ",
            properties.Select(x => ToSnakeCase(x.Name)));

        var parameters = string.Join(", ",
            properties.Select(x => "@" + ToSnakeCase(x.Name)));

        var sql =
            $"INSERT INTO {TableName} ({columns}) VALUES ({parameters})";

        using var connection = Connection;

        await connection.OpenAsync();

        using var command = new NpgsqlCommand(sql, connection);

        foreach(var property in properties)
        {
            var value = property.GetValue(entity);

            if(value is Enum)
            {
                command.Parameters.AddWithValue(
                    ToSnakeCase(property.Name),
                    value.ToString().ToUpper()
                );
            }
            else
            {
                command.Parameters.AddWithValue(
                    ToSnakeCase(property.Name),
                    value ?? DBNull.Value
                );
            }
        }


        await command.ExecuteNonQueryAsync();

    }


    public async Task<TEntity?> GetByIdAsync(int id)
    {
        var sql =
            $"SELECT * FROM {TableName} WHERE id = @id";


        using var connection = Connection;

        await connection.OpenAsync();


        using var command = new NpgsqlCommand(sql, connection);

        command.Parameters.AddWithValue("id", id);



        using var reader = await command.ExecuteReaderAsync();


        if(await reader.ReadAsync())
            return Map(reader);


        return null;
    }


    public async Task DeleteAsync(int id)
    {
        var sql =
            $"DELETE FROM {TableName} WHERE id = @id";


        using var connection = Connection;

        await connection.OpenAsync();


        using var command = new NpgsqlCommand(sql, connection);


        command.Parameters.AddWithValue("id", id);


        await command.ExecuteNonQueryAsync();
    }


    protected TEntity Map(NpgsqlDataReader reader)
    {

        var entity = new TEntity();


        foreach(var property in typeof(TEntity).GetProperties())
        {

            var column = ToSnakeCase(property.Name);


            var value = reader[column];


            if(value == DBNull.Value)
                continue;


            if(property.PropertyType.IsEnum)
            {
                var enumValue = Enum.Parse(
                    property.PropertyType,
                    value.ToString()!,
                    true
                );

                property.SetValue(
                    entity,
                    enumValue
                );
            }
            else
            {
                property.SetValue(
                    entity,
                    Convert.ChangeType(
                        value,
                        property.PropertyType
                    )
                );
            }

        }


        return entity;
    }


    private string ToSnakeCase(string name)
    {
        return string.Concat(
            name.Select((x,i)=>
                i > 0 && char.IsUpper(x)
                ? "_" + x
                : x.ToString()
            )
        ).ToLower();
    }
}