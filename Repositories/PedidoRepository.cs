using model;

namespace Repositories;

public class PedidoRepository : IPedidoRepository
{
    public Pedido ObterPedido(int pedidoId)
    {
        return new Pedido(10, Model.EStatusPedido.Finalizado);
    }

    public bool AtualizarPedido(Pedido pedido)
    {
        throw new NotImplementedException();
    }

    public Pedido IncluirPedido(Pedido pedido)
    {
        throw new NotImplementedException();
    }
}
