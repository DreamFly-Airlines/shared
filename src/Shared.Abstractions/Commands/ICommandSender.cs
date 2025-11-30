namespace Shared.Abstractions.Commands;

public interface ICommandSender
{
    public Task SendAsync(ICommand command, CancellationToken cancellationToken = default);
    
    public Task<TResult> SendAsync<TResult>(ICommand<TResult> command, CancellationToken cancellationToken = default);
}