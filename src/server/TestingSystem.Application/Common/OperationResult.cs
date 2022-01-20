using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace TestingSystem.Application.Common;

public interface IOperationResult
{
    public bool Success { get; }
    
    public Failure? Failure { get; }
}

public readonly struct OperationResult<T> : IOperationResult
{
    public OperationResult(T data)
    {
        Success = true;
        Data = data;
        Failure = default;
    }

    public OperationResult(Failure failure)
    {
        Success = false;
        Data = default;
        Failure = failure;
    }

    [MemberNotNullWhen(true, nameof(Data))]
    [MemberNotNullWhen(false, nameof(Failure))]
    public bool Success { get; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public T? Data { get; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Failure? Failure { get; }

    public static implicit operator OperationResult<T>(T value) 
        => new(value);

    public static implicit operator OperationResult<T>(Failure failure)
        => new(failure);

    public static implicit operator Task<OperationResult<T>>(OperationResult<T> result)
        => Task.FromResult(result);
}
