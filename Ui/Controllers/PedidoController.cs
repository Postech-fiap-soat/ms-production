using Microsoft.AspNetCore.Mvc;
using Model;
using Model.UserCases;
using Newtonsoft.Json;

namespace Ui.Controllers;

[ApiController]
[Route("[controller]")]
public class PedidoController : ControllerBase
{
    private readonly ILogger<PedidoController> _logger;
    private readonly IObterPedidoUserCase _obterPedidoUserCase;
    private readonly IIncluirPedidoUserCase _incluirPedidoUserCase;

    public PedidoController(ILogger<PedidoController> logger,
    IObterPedidoUserCase obterPedidoUserCase,
    IIncluirPedidoUserCase incluirPedidoUserCase)
    {
        _logger = logger;
        _obterPedidoUserCase = obterPedidoUserCase;
        _incluirPedidoUserCase = incluirPedidoUserCase;
    }

    [HttpGet(Name = "?pedidoId={pedidoId}")]
    public ActionResult Get(int pedidoId)
    {
        try
        {
            var pedido = _obterPedidoUserCase.Handle(pedidoId);
            return Ok(JsonConvert.SerializeObject(pedido));
        }
        catch (System.Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    //TODO: NÃO ESTA RECEBENDO O PEDIDO, DEVEMOS CRIAR UM DTO, NAO SEI A CAUSA AINDA
    public ActionResult Post([FromBody]Pedido pedido)
    {
        try
        {
            if(pedido == null) return NoContent();

            //pedido = _incluirPedidoUserCase.Handle(pedido.Id,(Model.EStatusPedido) pedido.Status);
            return Ok(JsonConvert.SerializeObject(pedido));
        }
        catch (System.Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
