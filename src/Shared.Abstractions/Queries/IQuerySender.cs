namespace Shared.Abstractions.Queries;

public interface IQuerySender
{
    public Task<TResult> SendAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default);
}