using Model;

namespace Model.UserCases;

public interface IListarPedidoPorStatusUserCase
{
    public IEnumerable<Pedido> Handle(EStatusPedido statusPedido);
}
