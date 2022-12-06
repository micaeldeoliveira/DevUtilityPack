using ElmahCore;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace DevUtilityPack.Api.Exceptions;

public class GlobalApiException
{
    private readonly RequestDelegate _next;

    public GlobalApiException(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            var hastag = Guid.NewGuid().ToString().Replace("-", "")[..5];
            ElmahExtensions.RaiseError(new Exception($"#{hastag}# - {ex.Message}"));
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        }
    }
}