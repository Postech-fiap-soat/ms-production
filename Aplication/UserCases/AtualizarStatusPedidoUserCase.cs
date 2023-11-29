using Model;
using Model.UserCases;
using Repositories;

namespace Aplication;

public class AtualizarStatusPedidoUserCase : IAtualizarStatusPedidoUserCase
{
    private readonly IPedidoRepository pedidoRepositorio;
    public AtualizarStatusPedidoUserCase(IPedidoRepository pedidoRepositorio)
    {
        this.pedidoRepositorio = pedidoRepositorio;
    }
    public bool Handle(int pedidoId, EStatusPedido statusPedido)
    {
        if (pedidoId == 0)
            throw new ArgumentException("pedidoId não pode ser 0");

        var pedido = this.pedidoRepositorio.ObterPedido(pedidoId);

        pedido.AtualizarStatus(statusPedido);

        return this.pedidoRepositorio.AtualizarPedido(pedido);
    }
}
