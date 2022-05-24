using System.Threading.Tasks;
using AppFidelidade.Domain.Shared.Contracts;

namespace AppFidelidade.Domain.Shared;

public static class Result
{
    public static Task<IResult> ResultAsync(bool success, string message = "", object data = null)
    {
        return Task.FromResult<IResult>(new GenericResult(success, message, data));
    }
}