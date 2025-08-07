using System.Net;
using System.Text.Json;
using FastEndpoints;
using KanbaniteAPI.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace KanbaniteAPI.Extension;

public static class ControllerExtension
{
    public static KanbaniteResponse<T> SendApiResponse<T>(this ControllerBase controller, T data, string message = "Success", HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        return KanbaniteResponse<T>.Success(data, message, (int)statusCode);
    }
    
    public static KanbaniteResponse<T> SendApiError<T>(this ControllerBase controller, List<string> errors, string message = "Error", HttpStatusCode statusCode = HttpStatusCode.BadRequest)
    {
        return KanbaniteResponse<T>.Fail(errors, message, (int)statusCode);
    }
}