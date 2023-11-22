using model;

namespace Model.UserCases;

public interface IIncluirPedidoUserCase
{
    public Pedido Handle(int pedidoId, EStatusPedido statusPedido);
}
