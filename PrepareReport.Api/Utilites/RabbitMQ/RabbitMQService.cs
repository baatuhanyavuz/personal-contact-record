using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

public class RabbitMQService : IDisposable
{
    private readonly IConfiguration _configuration;
    private readonly ConnectionFactory _factory;
    private readonly IConnection _connection;
    private readonly IModel _channel;

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


    public void StartConsuming(Action<string> messageHandler)
    {
        _channel.QueueDeclare(queue: "ReportQ",
                              durable: false,
                              exclusive: false,
                              autoDelete: false,
                              arguments: null);

        var consumer = new EventingBasicConsumer(_channel);

        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray(); 
            var message = Encoding.UTF8.GetString(body);
            messageHandler.Invoke(message);
        };

        _channel.BasicConsume(queue: "ReportQ",
                              autoAck: true,
                              consumer: consumer);
    }
    public void Dispose()
    {
        _channel.Dispose();
        _connection.Dispose();
    }
}
