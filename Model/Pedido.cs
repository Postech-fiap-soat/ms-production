using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Model;

[BsonIgnoreExtraElements]
public class Pedido
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string bsonid { get; set;}

    [BsonElement("Id")]
    public int Id { get; set; }

    [BsonElement("Status")]
    public EStatusPedido Status { get; set; }

    [BsonElement("DataAlteradoStatus")]
    public DateTime DataAlteradoStatus { get; set; }

    [BsonElement("Cliente")]
    public Client Client { get; set; }

    public Pedido(int pedidoId, EStatusPedido status, Client client)
    {
        this.Id = pedidoId;
        this.Client = client;
        this.AtualizarStatus(status);
    }

    public void AtualizarStatus(EStatusPedido status)
    {
        this.Status = status;
        DataAlteradoStatus = DateTime.Now;
    }
}
