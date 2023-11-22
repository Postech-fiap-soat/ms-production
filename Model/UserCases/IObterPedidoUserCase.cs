using model;

namespace Model.UserCases;

public interface IObterPedidoUserCase
{
    public Pedido Handle(int pedidoId);
}
