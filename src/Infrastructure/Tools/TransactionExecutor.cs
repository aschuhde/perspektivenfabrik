using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Tools;

public static class TransactionExecutor
{
    public static async Task<TransactionExecutionResult<T>> ExecuteInTransactionAndLogErrorIfFails<T>(this DbContext dbContext, Func<IDbContextTransaction, CancellationToken, Task<T>> action, ILogger logger, CancellationToken ct, [CallerMemberName] string callerName = "")
    {
        await using var transaction = await dbContext.Database.BeginTransactionAsync(ct);
        try
        {
            return new TransactionExecutionResult<T> { HasResult = true, Result = await action(transaction, ct) };
        }
        catch (Exception exception)
        {
            await transaction.RollbackAsync(ct);
            logger.LogError(exception, "Executing the action '{ActionName}' in a transaction failed.", callerName);
            return new TransactionExecutionResult<T> { HasResult = false, Exception = exception };
        }
    }
}

public class TransactionExecutionResult<T>
{
    public required bool HasResult { get; set; }
    public T? Result { get; set; }
    public Exception? Exception { get; set; }
}
