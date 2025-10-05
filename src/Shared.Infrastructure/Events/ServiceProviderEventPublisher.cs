using Microsoft.Extensions.DependencyInjection;
using Shared.Abstractions.Events;

namespace Shared.Infrastructure.Events;

public class ServiceProviderEventPublisher(IServiceProvider serviceProvider) : IEventPublisher
{
    public async Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default) 
        where TEvent : notnull
    {
        var handlerType = typeof(IEventHandler<>).MakeGenericType(@event.GetType());
        var handlers = serviceProvider.GetServices(handlerType);
        var handleMethod = handlerType.GetMethod(nameof(IEventHandler<object>.HandleAsync))
                           ?? throw new ArgumentNullException(nameof(IEventHandler<object>.HandleAsync));
        foreach (var handler in handlers)
            await (Task)handleMethod.Invoke(handler, [@event, cancellationToken])!;
    }
}