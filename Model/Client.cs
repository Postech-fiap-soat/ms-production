using MongoDB.Bson.Serialization.Attributes;

namespace Model;

public class Client {

    [BsonElement("Identificacao")]
    public required string Identificacao { get; set; }
    [BsonElement("Email")]
    public required string Email { get; set; }
    [BsonElement("NumeroIdentificacao")]
    public required string NumeroIdentificacao { get; set; }
    [BsonElement("Nome")]
    public required string Nome { get; set; }
    [BsonElement("Sobrenome")]
    public required string Sobrenome { get; set; }

}