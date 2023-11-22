namespace Model.UserCases;

public interface IAtualizarStatusPedidoUserCase
{
    public bool Handle(int pedidoId, EStatusPedido statusPedido);
}
