using Npgsql;
using DotNetEnv;

namespace Src.Shared.Database;

public static class DatabaseConnection{
    /// <summary>
    /// Conexão com o banco de dados utilizando variaveis do ambiente .env
    /// </summary>
    /// <returns>Uma instância de Npgsqlconnection realizando a conexão com o banco de dados</returns>
    public static NpgsqlConnection GetConnection()
    {
        Env.Load();
        var host = Environment.GetEnvironmentVariable("HOST");
        var port = Environment.GetEnvironmentVariable("PORT");
        var user = Environment.GetEnvironmentVariable("USERNAME");
        var password = Environment.GetEnvironmentVariable("PASSWORD");
        var database = Environment.GetEnvironmentVariable("DATABASE");

        var connectionString = $"Host={host};Port={port};Username={user};Password={password};Database={database}";
        
        return new NpgsqlConnection(connectionString); 
    }
}