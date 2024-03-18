namespace UrlShortner.Domain.Interfaces;

public interface IMessageBroker
{
    Task PublishAsync<T>(T messagebody);
}