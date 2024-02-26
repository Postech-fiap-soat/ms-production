using System.Text.Json.Serialization;

namespace RabbitMq.Contracts;

public class Order
{
    public required string order_id { get; set; }
    public required string total_price { get; set; }
    public required Client client { get; set; }
}

public class Client
{
    public required string email { get; set; }
    public required string cpf { get; set; }
    public required string name { get; set; }
    public required string second_name { get; set; }

}

// public class Payment {
//     public string Id { get; set; }
//     public string OrderId     { get; set; }
//     public string TotalPrice  { get; set; }
//     public string Status      { get; set; }
//     public Order Order       { get; set; }
//     public Client Client      { get; set; }
// }

// public class Order {
//     public string ItemsTitle      { get; set; }
//     public string ItemsQuantity       { get; set; }
//     public string ItemsUnitPrice   { get; set; }
// }


