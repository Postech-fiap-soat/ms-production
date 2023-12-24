using Model;
using Model.UserCases;
using Repositories;

namespace Aplication;

public class ObterPedidoUserCase : IObterPedidoUserCase
{
    private readonly IPedidoRepository pedidoRepositorio;

    public ObterPedidoUserCase(IPedidoRepository pedidoRepositorio)
    {
        this.pedidoRepositorio = pedidoRepositorio;
    }
    public Pedido Handle(int pedidoId)
    {
        if(pedidoId == 0)
            throw new ArgumentException("pedidoId não pode ser 0");
        
        return this.pedidoRepositorio.ObterPedido(pedidoId);
    }
}
