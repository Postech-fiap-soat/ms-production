using MongoDB.Bson.Serialization.Attributes;

namespace Model;

[BsonIgnoreExtraElements]
public class Pedido
{
    [BsonElement("Id")]
    public int Id { get; set; }

    [BsonElement("Status")]
    public EStatusPedido Status { get; set; }

    [BsonElement("DataAlteradoStatus")]
    public DateTime DataAlteradoStatus { get; set; }

    public Pedido()
    {
            
    }
    public Pedido(int pedidoId, EStatusPedido status)
    {
        this.Id = pedidoId;
        this.AtualizarStatus(status);
    }

    public void AtualizarStatus(EStatusPedido status)
    {
        this.Status = status;
        DataAlteradoStatus = DateTime.Now;
    }
}
