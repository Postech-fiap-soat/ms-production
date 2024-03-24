using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.UserCases;
using Newtonsoft.Json;

namespace Ui.Controllers;

[ApiController]
[Route("[controller]")]
[ExcludeFromCodeCoverage]
public class PedidoController : ControllerBase
{
    private readonly ILogger<PedidoController> _logger;
    private readonly IObterPedidoUserCase _obterPedidoUserCase;
    private readonly IAtualizarStatusPedidoUserCase _atualizarStatusPedidoUserCase;

    public PedidoController(ILogger<PedidoController> logger,
    IObterPedidoUserCase obterPedidoUserCase,
    IAtualizarStatusPedidoUserCase atualizarStatusPedidoUserCase)
    {
        _logger = logger;
        _obterPedidoUserCase = obterPedidoUserCase;
        _atualizarStatusPedidoUserCase = atualizarStatusPedidoUserCase;
    }

    [HttpGet(Name = "?pedidoId={pedidoId}")]
    public ActionResult Get(int pedidoId)
    {
        try
        {
            var pedido = _obterPedidoUserCase.Handle(pedidoId);

            if (pedido == null) return NoContent();

            return Ok(JsonConvert.SerializeObject(pedido));
        }
        catch (System.Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public ActionResult Put([FromQuery] int pedidoId,  [FromBody] EStatusPedido statusPedido)
    {
        try
        {
            if (pedidoId <= 0) return NoContent();

            _ = _atualizarStatusPedidoUserCase.Handle(pedidoId, statusPedido);
            var pedido = _obterPedidoUserCase.Handle(pedidoId);

            return Ok(JsonConvert.SerializeObject(pedido));
        }
        catch (System.Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
