namespace Shared.Abstractions.IntegrationEvents;

public interface IIntegrationEventPublisher
{
    public Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default)
        where TEvent : IIntegrationEvent;
}