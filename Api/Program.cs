using CadastroPessoa.Interfaces;
using CadastroPessoa.Repository;
using CadastroPessoa.Services;

using CadastroTransacao.Interfaces;
using CadastroTransacao.Repository;
using CadastroTransacao.Services;

using ConsultaTotais.Interfaces;
using ConsultaTotais.Repository;
using ConsultaTotais.Services;

using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions
            .Converters
            .Add(new JsonStringEnumConverter());
    });

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddScoped<
    IPessoaRepository,
    PessoaRepository
>();

builder.Services.AddScoped<
    IPessoaService,
    PessoaService
>();

builder.Services.AddScoped<
    ITransacaoRepository,
    TransacaoRepository
>();

builder.Services.AddScoped<
    ITransacaoService,
    TransacaoService
>();

builder.Services.AddScoped<
    ITotaisRepository,
    TotaisRepository
>();

builder.Services.AddScoped<
    ITotaisService,
    TotaisService
>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("frontend", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors("frontend");

if(app.Environment.IsDevelopment())
{

    app.UseSwagger();

    app.UseSwaggerUI();

}

app.UseHttpsRedirection();


app.MapControllers();


app.Run();