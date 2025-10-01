namespace Shared.Abstractions.Events;

public interface IEventHandler<in TEvent> where TEvent : notnull
{
    public Task HandleAsync(TEvent @event, CancellationToken cancellationToken = default);
}