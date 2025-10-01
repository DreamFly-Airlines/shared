namespace Shared.Abstractions.Commands;

public interface ICommandSender
{
    public Task SendAsync(ICommand command, CancellationToken cancellationToken = default);
}