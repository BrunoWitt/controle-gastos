using CadastroPessoa.Interfaces;
using CadastroPessoa.Models;
using Microsoft.AspNetCore.Mvc;

namespace CadastroPessoa.Controllers;

[ApiController]
[Route("api/pessoas")]
public class PessoaController : ControllerBase
{

    private readonly IPessoaService _service;


    public PessoaController(
        IPessoaService service
    )
    {
        _service = service;
    }


    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var pessoas = await _service.Listar();

        return Ok(pessoas);
    }


    [HttpPost]
    public async Task<IActionResult> Post(
        Pessoa pessoa
    )
    {
        await _service.Criar(pessoa);

        return Created("", pessoa);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(
        int id
    )
    {
        await _service.Deletar(id);

        return NoContent();
    }

}