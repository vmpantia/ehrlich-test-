namespace PizzaPlace.Domain.Results.Errors
{
    public class CommonError
    {
        public static Error Unexpected<TRequest>(Exception exception) => new($"{typeof(TRequest).Name}.{nameof(Exception)}", exception.ToString());
    }
}
