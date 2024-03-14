namespace Urlshortner.Infrastructure.Interfaces;

public interface IMessageBroker
{
    Task PublishAsync<T>(T messagebody);
}