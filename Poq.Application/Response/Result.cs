using System.Collections.Generic;

namespace Poq.Application.Response
{
    public class Result<T>
    {
        public bool IsSuccess { get; init; }
        public T Value { get; init; }
        public List<string> Errors { get; init; }

        public static Result<T> Success(T value) => new Result<T> { IsSuccess = true, Value = value };
        public static Result<T> Failure(List<string> errors) => new Result<T> { IsSuccess = false, Errors = errors };
    }
}
