using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Model;
using Model.UserCases;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        Console.WriteLine(host);
        var port = Convert.ToInt32(configuration["RabbitMqConfig:Port"]);
        Console.WriteLine(port);
        var user = configuration["RabbitMqConfig:User"];
        Console.WriteLine(user);
        var password = configuration["RabbitMqConfig:Password"];
        Console.WriteLine(password);
        var virtualHost = configuration["RabbitMqConfig:VirtualHost"];
        Console.WriteLine(virtualHost);

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

        _channel.ExchangeDeclare("ex_producao", ExchangeType.Direct, true, false);

        _channel.QueueDeclare(queue: "queue_producao",
                         durable: true,
                         exclusive: false,
                         autoDelete: false,
                         arguments: null);

        _channel.QueueBind("queue_producao", "ex_producao", "soatkey");

        _channel.QueueDeclare(queue: "queue_producao-reply",
                         durable: true,
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
            var basicProperties = _channel.CreateBasicProperties();
            basicProperties.CorrelationId = Guid.NewGuid().ToString();
            try
            {
                var headers = ea.BasicProperties.Headers;

                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var json = JToken.Parse(message);

                Console.WriteLine($" [x] Received {message}");

                var order = JsonConvert.DeserializeObject<OrderDetails>(json.ToString());
                var client = new Model.Client()
                {
                    Identificacao = order.client.type_identification,
                    NumeroIdentificacao = order.client.number_identification,
                    Email = order.client.email,
                    Nome = order.client.name,
                    Sobrenome = order.client.surname,
                };

                _incluirPedidoUserCase.Handle(order.order_id, EStatusPedido.Recebido, client);

                //_channel.BasicPublish("", ea.BasicProperties.ReplyTo, basicProperties, Encoding.UTF8.GetBytes("true"));

            }
            catch (System.Exception ex)
            {
                //_channel.BasicPublish("", ea.BasicProperties.ReplyTo, basicProperties, Encoding.UTF8.GetBytes("false"));
            }

        };

        _channel.BasicConsume("queue_producao", false, consumer);

        return Task.CompletedTask;
    }

    public override void Dispose()
    {
        _channel.Close();
        _connection.Close();
        base.Dispose();
    }
}
