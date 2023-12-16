using RabbitMQ.Client;
using System;
using System.Text;

public class RabbitMQService
{
    private readonly ConnectionFactory _factory;
    private readonly IConnection _connection;
    private readonly IModel _channel;
    private readonly IConfiguration _configuration;

    public RabbitMQService(IConfiguration configuration)
    {
        _configuration = configuration;

        _factory = new ConnectionFactory()
        {
            HostName = _configuration["RabbitMQConfig:HostName"],
            Port = int.Parse(_configuration["RabbitMQConfig:Port"]),
            UserName = _configuration["RabbitMQConfig:UserName"],
            Password = _configuration["RabbitMQConfig:Password"]
        };

        _connection = _factory.CreateConnection();
        _channel = _connection.CreateModel();
    }
 
    public void SendMessage(string message)
    {
        _channel.QueueDeclare(queue: "ReportQ",
                              durable: false,
                              exclusive: false,
                              autoDelete: false,
                              arguments: null);

        var body = Encoding.UTF8.GetBytes(message);

        _channel.BasicPublish(exchange: "",
                              routingKey: "ReportQ",
                              basicProperties: null,
                              body: body);

        Console.WriteLine($"Send message: {message}");
    }

    public void Dispose()
    {
        _channel.Dispose();
        _connection.Dispose();
    }
}
