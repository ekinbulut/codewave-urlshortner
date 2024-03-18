using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using UrlShortner.Domain.Interfaces;

namespace Urlshortner.Infrastructure.Services;

public class MessageBroker : IMessageBroker
{
    private readonly ConnectionFactory _connectionFactory;

    public MessageBroker(ConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task PublishAsync<T>(T messagebody)
    {
        var exchangeName = "urlshortner_ex";
        using var connection = _connectionFactory.CreateConnection();
        using var channel = connection.CreateModel();
        
        channel.ExchangeDeclare(exchangeName, ExchangeType.Fanout);

        await Task.Run(() =>
        {
            var message = JsonConvert.SerializeObject(messagebody);
            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(exchangeName, string.Empty, null, body);
            return Task.FromResult(Task.CompletedTask);
        });
    }
}