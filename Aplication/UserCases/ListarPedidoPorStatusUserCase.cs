using Model;
using Model.UserCases;
using Repositories;

namespace Aplication;

public class ListarPedidoPorStatusUserCase : IListarPedidoPorStatusUserCase
{
    private readonly IPedidoRepository pedidoRepositorio;

    public ListarPedidoPorStatusUserCase(IPedidoRepository pedidoRepositorio)
    {
        this.pedidoRepositorio = pedidoRepositorio;
    }
    public IEnumerable<Pedido> Handle(EStatusPedido eStatusPedido)
    {
        return this.pedidoRepositorio.ObterPedidos(eStatusPedido);
    }
}
