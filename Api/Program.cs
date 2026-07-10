using CadastroPessoa.Interfaces;
using CadastroPessoa.Repository;
using CadastroPessoa.Services;

using CadastroTransacao.Interfaces;
using CadastroTransacao.Repository;
using CadastroTransacao.Services;

using ConsultaTotais.Interfaces;
using ConsultaTotais.Repository;
using ConsultaTotais.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

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

var app = builder.Build();

if(app.Environment.IsDevelopment())
{

    app.UseSwagger();

    app.UseSwaggerUI();

}

app.UseHttpsRedirection();


app.MapControllers();


app.Run();