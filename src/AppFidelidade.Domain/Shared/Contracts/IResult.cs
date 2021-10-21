namespace AppFidelidade.Core.Shared.Contracts
{
    public interface  IResult
    {
        bool Success { get; set; }
        string Message { get; set; }
        object Data { get; set; }
    }
}