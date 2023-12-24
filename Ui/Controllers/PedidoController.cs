using Microsoft.AspNetCore.Mvc;
using Model.UserCases;

namespace Ui.Controllers;

[ApiController]
[Route("[controller]")]
public class PedidoController : ControllerBase
{
    private readonly ILogger<PedidoController> _logger;
    private readonly IObterPedidoUserCase _obterPedidoUserCase;

    public PedidoController(ILogger<PedidoController> logger,
    IObterPedidoUserCase obterPedidoUserCase)
    {
        _logger = logger;
        _obterPedidoUserCase = obterPedidoUserCase;
    }

    [HttpGet(Name = "?pedidoId={pedidoId}")]
    public ActionResult Get(int pedidoId)
    {
        try
        {
            var pedido = _obterPedidoUserCase.Handle(pedidoId);
            return Ok(pedido);
        }
        catch (System.Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
