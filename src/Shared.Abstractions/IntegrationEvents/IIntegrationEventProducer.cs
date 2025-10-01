namespace Shared.Abstractions.IntegrationEvents;

public interface IIntegrationEventProducer
{
    public Task ProduceAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default)
        where TEvent : IIntegrationEvent;
}