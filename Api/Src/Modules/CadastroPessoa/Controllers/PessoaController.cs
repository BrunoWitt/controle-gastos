using CadastroPessoa.Interfaces;
using CadastroPessoa.Models;
using Microsoft.AspNetCore.Mvc;
using CadastroPessoa.DTOs;

namespace CadastroPessoa.Controllers;

[ApiController]
[Route("api/pessoa")]
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
        CreatePessoaDTO pessoaDTO
    )
    {

        var pessoa = new Pessoa
        {
            Nome = pessoaDTO.Nome,
            Idade = pessoaDTO.Idade
        };


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