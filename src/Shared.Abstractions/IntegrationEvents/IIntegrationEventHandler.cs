namespace Shared.Abstractions.IntegrationEvents;

public interface IIntegrationEventHandler<in TEvent> where TEvent : IIntegrationEvent
{
    public Task HandleAsync(TEvent integrationEvent, CancellationToken cancellationToken = default);
}