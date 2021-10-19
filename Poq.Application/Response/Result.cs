namespace Poq.Application.Response
{
    public class Result<T>
    {
        public bool IsSuccess { get; init; }
        public T Value { get; init; }
        public string Error { get; init; }

        public static Result<T> Success(T value) => new Result<T> { IsSuccess = true, Value = value };
    }
}
