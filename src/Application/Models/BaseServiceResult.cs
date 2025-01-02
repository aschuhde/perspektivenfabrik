using System.Net;
using Application.Common.Response;

namespace Application.Models;

public class BaseServiceResult
{
    public required bool Success { get; init; }
    public Exception? Exception { get; init; }
}
