using Shared.Abstractions.IntegrationEvents;

namespace Shared.IntegrationEvents.Bookings;

public class BookingPaymentMarkFailedIntegrationEvent(string BookRef) : IIntegrationEvent
{
    public static string EventName => "BookingPaymentMarkFailed";
}