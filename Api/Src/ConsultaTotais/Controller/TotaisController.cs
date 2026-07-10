using ConsultaTotais.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace MinhaApi.Controllers;


[ApiController]
[Route("api/totais")]
public class TotaisController : ControllerBase
{

    private readonly ITotaisService _service;



    public TotaisController(
        ITotaisService service
    )
    {
        _service = service;
    }




    [HttpGet]
    public async Task<IActionResult> Get()
    {

        var resultado =
            await _service.Consultar();


        return Ok(resultado);

    }

}