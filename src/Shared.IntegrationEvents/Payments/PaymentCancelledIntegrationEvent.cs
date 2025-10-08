using Shared.Abstractions.IntegrationEvents;

namespace Shared.IntegrationEvents.Payments;

public record PaymentCancelledIntegrationEvent(string BookRef) : IIntegrationEvent
{
    public string EventName => "PaymentCancelled";
}