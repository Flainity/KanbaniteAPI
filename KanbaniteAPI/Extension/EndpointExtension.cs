using System.Net;
using System.Text.Json;
using FastEndpoints;
using KanbaniteAPI.Contracts;

namespace KanbaniteAPI.Extension;

public static class EndpointExtension
{
    public static async Task SendApiResponseAsync<T>(this IEndpoint endpoint, T data, string message = "Success", HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        var result = KanbaniteResponse<T>.Success(data, message, (int)statusCode);
        endpoint.HttpContext.Response.StatusCode = (int)statusCode;

        await endpoint.HttpContext.Response.WriteAsJsonAsync(result, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
    }

    public static async Task SendApiErrorAsync(this IEndpoint endpoint, List<string> errors, string message = "Error", HttpStatusCode statusCode = HttpStatusCode.BadRequest)
    {
        var result = KanbaniteResponse<object>.Fail(errors, message, (int)statusCode);
        endpoint.HttpContext.Response.StatusCode = (int)statusCode;

        await endpoint.HttpContext.Response.WriteAsJsonAsync(result, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
    }
}