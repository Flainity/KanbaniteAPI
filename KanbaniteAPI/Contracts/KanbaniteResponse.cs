namespace KanbaniteAPI.Contracts;

public class KanbaniteResponse<T> : KanbaniteResponseBase
{
    public T? Data { get; set; }

    public static KanbaniteResponse<T> Success(T data, string message = "Success", int statusCode = 200)
        => new()
        {
            StatusCode = statusCode,
            Message = message,
            Data = data,
            Errors = []
        };

    public static KanbaniteResponse<T> Fail(List<string> errors, string message = "Failed", int statusCode = 400)
        => new()
        {
            StatusCode = statusCode,
            Message = message,
            Data = default,
            Errors = errors
        };
}