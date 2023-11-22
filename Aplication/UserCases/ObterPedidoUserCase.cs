using model;
using Model.UserCases;
using Repositories;

namespace Aplication;

public class ObterPedidoUserCase : IObterPedidoUserCase
{
    private readonly IPedidoRepositorio pedidoRepositorio;

    public ObterPedidoUserCase(IPedidoRepositorio pedidoRepositorio)
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
