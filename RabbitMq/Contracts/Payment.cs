using System.Text.Json.Serialization;


namespace RabbitMq.Contracts;

public class OrderDetails
{
    public required int order_id { get; set; }
    public required decimal total_price { get; set; }
    public required Client client { get; set; }
    public required Order order { get; set; }
}

public class Client
{
    public required string type_identification { get; set; }
    public required string email { get; set; }
    public required string number_identification { get; set; }
    public required string name { get; set; }
    public required string surname { get; set; }

}

public class Order
{
    public required string items_title { get; set; }
    public required int items_quantity { get; set; }
    public required decimal items_unit_price { get; set; }
}