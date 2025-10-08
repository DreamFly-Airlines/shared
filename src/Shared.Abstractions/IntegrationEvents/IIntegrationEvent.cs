namespace Shared.Abstractions.IntegrationEvents;

public interface IIntegrationEvent
{
    public static abstract string EventName { get; }
}