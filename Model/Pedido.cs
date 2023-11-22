using Model;

namespace model;

public class Pedido
{
    public int Id;
    public EStatusPedido Status;
    public DateTime DataAlteradoStatus;

    public Pedido(int pedidoId, EStatusPedido status)
    {
        this.Id = pedidoId;
        this.AtualizarStatus(status);
    }

    public void AtualizarStatus(EStatusPedido status){
        this.Status = status;
        DataAlteradoStatus = DateTime.Now;
    }
}
