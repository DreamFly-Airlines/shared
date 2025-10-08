using Shared.Abstractions.IntegrationEvents;

namespace Shared.IntegrationEvents.Payments;

public record PaymentConfirmedIntegrationEvent(string BookRef) : IIntegrationEvent
{
    public string EventName => "PaymentConfirmed";
}