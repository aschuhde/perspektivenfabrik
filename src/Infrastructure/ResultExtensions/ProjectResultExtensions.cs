using Application.Models.ProjectService;
using Infrastructure.Tools;

namespace Infrastructure.ResultExtensions;

public static class ProjectResultExtensions
{
    public static CreateorUpdateProjectResult ToCreateProjectResult(this TransactionExecutionResult<CreateorUpdateProjectResult> transactionExecutionResult) =>
        transactionExecutionResult.HasResult
            ? transactionExecutionResult.Result!
            : new CreateorUpdateProjectResult { Success = false, Exception = transactionExecutionResult.Exception };
}
