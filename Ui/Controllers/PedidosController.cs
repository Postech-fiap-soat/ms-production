using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.UserCases;
using Newtonsoft.Json;
using Ui.Dto;

namespace Ui.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
[ExcludeFromCodeCoverage]
public class PedidosController : ControllerBase
{
    private readonly ILogger<PedidosController> _logger;
    private readonly IListarPedidoPorStatusUserCase _listarPedidoPorStatusUserCase;

    public PedidosController(ILogger<PedidosController> logger,
    IListarPedidoPorStatusUserCase listarPedidoPorStatusUserCase)
    {
        _logger = logger;
        _listarPedidoPorStatusUserCase = listarPedidoPorStatusUserCase;
    }

    [HttpGet(Name = "Listar pedidos por status")]
    public ActionResult ListarPedidos(EStatusPedido statusPedido)
    {
        try
        {
            var pedido = _listarPedidoPorStatusUserCase.Handle(statusPedido);

            if (pedido == null) return NoContent();

            return Ok(JsonConvert.SerializeObject(pedido));
        }
        catch (System.Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}
