using PizzaPlace.Domain.Models.Enums;

namespace PizzaPlace.Domain.Results
{
    public class Result<TResponse>
    {
        // Result without any data or error
        private Result()
        {
            IsSuccess = true;
            Data = default;
            Error = null;
        }

        // Result with data
        private Result(TResponse data)
        {
            IsSuccess = true;
            Data = data;
            Error = null;
        }

        // Result with error
        private Result(Error error)
        {
            IsSuccess = false;
            Data = default;
            Error = error;
        }

        public bool IsSuccess { get; }
        public TResponse? Data { get; }
        public Error? Error { get; }

        public static Result<TResponse> Success() => new();
        public static Result<TResponse> Success(TResponse data) => new(data);
        public static Result<TResponse> Failure(Error error) => new(error);
    }

    public sealed record Error(ErrorType Type, string Code, object Description) { }
}
