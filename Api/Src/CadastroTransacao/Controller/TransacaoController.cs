using CadastroTransacao.Interfaces;
using CadastroTransacao.Models;
using Microsoft.AspNetCore.Mvc;


namespace MinhaApi.Controllers;


[ApiController]
[Route("api/transacoes")]
public class TransacaoController : ControllerBase
{
    private readonly ITransacaoService _service;

    public TransacaoController(
        ITransacaoService service
    )
    {
        _service = service;
    }


    [HttpGet]
    public async Task<IActionResult> Get()
    {

        var transacoes =
            await _service.Listar();


        return Ok(transacoes);

    }


    [HttpPost]
    public async Task<IActionResult> Post(
        Transacao transacao
    )
    {

        try
        {

            await _service.Criar(transacao);


            return Created("", transacao);

        }
        catch(Exception ex)
        {

            return BadRequest(ex.Message);

        }

    }

}