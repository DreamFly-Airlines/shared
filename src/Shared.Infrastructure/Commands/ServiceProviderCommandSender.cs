using Microsoft.Extensions.DependencyInjection;
using Shared.Abstractions.Commands;

namespace Shared.Infrastructure.Commands;

public class ServiceProviderCommandSender(
    IServiceProvider serviceProvider) : ICommandSender
{
    public async Task SendAsync(ICommand command, CancellationToken cancellationToken = default)
    {
        var commandType = command.GetType();
        var commandHandlerType = typeof(ICommandHandler<>).MakeGenericType(commandType);
        await (Task)GetAndInvokeHandlerOrThrow(
            commandHandlerType,
            command, 
            cancellationToken);
    }

    public async Task<TResult> SendAsync<TResult>(ICommand<TResult> command, CancellationToken cancellationToken = default)
    {
        var commandType = command.GetType();
        var resultType = typeof(TResult);
        var commandHandlerType = typeof(ICommandHandler<,>).MakeGenericType(commandType, resultType);
        return await (Task<TResult>)GetAndInvokeHandlerOrThrow(
            commandHandlerType, 
            command, 
            cancellationToken);
    }

    private object GetAndInvokeHandlerOrThrow(
        Type commandHandlerType, 
        object command, 
        CancellationToken cancellationToken = default)
    {
        const string handleAsyncMethodName = nameof(ICommandHandler<ICommand>.HandleAsync);
        var commandHandler = serviceProvider.GetRequiredService(commandHandlerType);
        var resultObject = commandHandlerType
                                   .GetMethod(handleAsyncMethodName)?
                                   .Invoke(commandHandler, [command, cancellationToken])
                               ?? throw new MethodAccessException(
                                   $"Cannot find or invoke method \"{handleAsyncMethodName}\" " +
                                   $"of {commandHandlerType.Name}");
        return resultObject;
    }
}