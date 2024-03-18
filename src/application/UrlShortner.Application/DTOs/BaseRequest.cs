namespace UrlShortner.Application.DTOs;

public abstract class BaseRequest
{
    public Guid TransactionId { get; set; } = Guid.NewGuid();
}