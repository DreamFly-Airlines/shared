using Shared.Abstractions.IntegrationEvents;

namespace Shared.IntegrationEvents.Bookings;

public record BookingPaidIntegrationEvent(string BookRef) : IIntegrationEvent
{
    public static string EventName => "BookingPaid";
}