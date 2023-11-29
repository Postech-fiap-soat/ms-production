using model;
using Model;
using Model.UserCases;
using Repositories;

namespace Aplication;

public class IncluirPedidoUserCase : IIncluirPedidoUserCase
{
    private readonly IPedidoRepository pedidoRepositorio;
    public IncluirPedidoUserCase(IPedidoRepository pedidoRepositorio)
    {
        this.pedidoRepositorio = pedidoRepositorio;
    }


    public Pedido Handle(int pedidoId, EStatusPedido statusPedido)
    {
        if(pedidoId == 0)
            throw new ArgumentException("pedidoId não pode ser 0");

        var pedido = new Pedido(pedidoId, statusPedido);

        return this.pedidoRepositorio.IncluirPedido(pedido);
    }
}
