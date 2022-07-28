namespace AlphaCentauri.CrossCutting;

public class Result : IResult
{
    protected Result() { }

    public bool Failed => !Succeeded;

    public string Message { get; protected set; }

    public bool Succeeded { get; protected set; }

    public static IResult Fail(string message) => new Result { Succeeded = false, Message = message };

    public static IResult Success() => new Result { Succeeded = true };
}

public sealed class Result<T> : Result, IResult<T>
{
    private Result() { }

    public T Data { get; init; }

    public new static IResult<T> Fail(string message) => new Result<T> { Succeeded = false, Message = message };

    public static IResult<T> Success(T data) => new Result<T> { Succeeded = true, Data = data };
}
