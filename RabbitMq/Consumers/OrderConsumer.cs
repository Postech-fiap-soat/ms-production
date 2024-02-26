using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Model;
using Model.UserCases;
using Newtonsoft.Json;
using RabbitMq.Contracts;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMq;

public class OrderConsumer : BackgroundService
{
    private IConnection _connection;
    private IModel _channel;
    private IIncluirPedidoUserCase _incluirPedidoUserCase;

    public OrderConsumer(IConfiguration configuration, 
    IIncluirPedidoUserCase incluirPedidoUserCase)
    {
        _incluirPedidoUserCase = incluirPedidoUserCase;
        this.InitRabbit(configuration);
    }

    public void InitRabbit(IConfiguration configuration)
    {   
        var host = configuration["RabbitMqConfig:Host"];
        var port = Convert.ToInt32(configuration["RabbitMqConfig:Port"]);
        var user = configuration["RabbitMqConfig:User"];
        var password = configuration["RabbitMqConfig:Password"];
        var virtualHost = configuration["RabbitMqConfig:VirtualHost"];

        var factory = new ConnectionFactory
        {
            HostName = host,
            UserName = user,
            Password = password,
            Port = port,
            VirtualHost = virtualHost
        };

        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();

        _channel.QueueDeclare(queue: "hello",
                         durable: false,
                         exclusive: false,
                         autoDelete: false,
                         arguments: null);
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        stoppingToken.ThrowIfCancellationRequested();

        Console.WriteLine(" [*] Waiting for messages.");

        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);

            var order = JsonConvert.DeserializeObject<Order>(message);

            _incluirPedidoUserCase.Handle(Convert.ToInt32(order.order_id), EStatusPedido.Recebido);

            Console.WriteLine($" [x] Received {message}");
        };

        _channel.BasicConsume("hello", true, consumer);

        return Task.CompletedTask;
    }

    public override void Dispose()
    {
        _channel.Close();
        _connection.Close();
        base.Dispose();
    }
}
