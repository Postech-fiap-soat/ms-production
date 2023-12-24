using Model;

namespace Repositories;

public class PedidoRepository : IPedidoRepository
{
    public Pedido ObterPedido(int pedidoId)
    {
        return new Pedido(10, Model.EStatusPedido.Finalizado);
    }

    public bool AtualizarPedido(Pedido pedido)
    {
        return true;
    }

    public Pedido IncluirPedido(Pedido pedido)
    {
       return pedido;
    }
}
