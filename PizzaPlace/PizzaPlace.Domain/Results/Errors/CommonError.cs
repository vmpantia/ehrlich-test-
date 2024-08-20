using PizzaPlace.Domain.Models.Enums;

namespace PizzaPlace.Domain.Results.Errors
{
    public class CommonError
    {
        public static Error Unexpected<TRequest>(Exception exception) => new(ErrorType.Unexpected, $"{typeof(TRequest).Name}.{nameof(Exception)}", exception.ToString());
        public static Error NotFoundById<TRequest, TEntity>(string id) => new(ErrorType.NotFound, $"{typeof(TRequest).Name}.{typeof(TEntity).Name}", $"Data with Id of '{id}' is not found in the database.");
    }
}
