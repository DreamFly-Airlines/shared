using Microsoft.Extensions.DependencyInjection;
using Shared.Abstractions.IntegrationEvents;

namespace Shared.Infrastructure.IntegrationEvents;

public class ServiceProviderIntegrationEventPublisher(
    IServiceProvider serviceProvider) : IIntegrationEventPublisher
{
    public async Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default) 
        where TEvent : IIntegrationEvent
    {
        var handlerType = typeof(IIntegrationEventHandler<>).MakeGenericType(@event.GetType());
        const string handleMethodName = nameof(IIntegrationEventHandler<IIntegrationEvent>.HandleAsync); 
        var handleMethodInfo = handlerType.GetMethod(handleMethodName) 
                         ?? throw new MissingMethodException($"Handler method \"{handleMethodName}\" not found");
        var handlers = serviceProvider.GetServices(handlerType);
        foreach (var handler in handlers)
            await (Task)handleMethodInfo.Invoke(handler, [@event, cancellationToken])!;
    }
}