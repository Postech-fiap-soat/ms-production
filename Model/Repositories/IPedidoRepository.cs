using model;

namespace Repositories;

public interface IPedidoRepository
{
    public Pedido ObterPedido(int pedidoId);

    public bool AtualizarPedido(Pedido pedido);

    public Pedido IncluirPedido(Pedido pedido);
}
