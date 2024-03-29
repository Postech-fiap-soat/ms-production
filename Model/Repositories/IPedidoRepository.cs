using Model;

namespace Repositories;

public interface IPedidoRepository
{
    public Pedido ObterPedido(int pedidoId);

    public bool AtualizarPedido(Pedido pedido);

    public Pedido IncluirPedido(Pedido pedido);

    public IEnumerable<Pedido> ObterPedidos(EStatusPedido statusPedido);
}
