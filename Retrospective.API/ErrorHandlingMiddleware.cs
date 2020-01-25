using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Retrospective.API.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Retrospective.API
{
  public class ErrorHandlingMiddleware
  {
    // Since this demo users no DB, save the exceptions in memory for now
    public static List<ExceptionLog> Exceptions = new List<ExceptionLog>();

    private readonly RequestDelegate next;
    public ErrorHandlingMiddleware(RequestDelegate next)
    {
      this.next = next;
    }

    public async Task Invoke(HttpContext context /* other dependencies */)
    {
      try
      {
        await next(context);
      }
      catch (Exception ex)
      {
        await HandleExceptionAsync(context, ex);
      }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
      // Log the exception
      Exceptions.Add(new ExceptionLog
      {
        Exception = ex,
        Context = context
      });
      var code = HttpStatusCode.InternalServerError; // 500 if unexpected

      if (ex is NotFoundException) code = HttpStatusCode.NotFound;
      else if (ex is UnauthorizedException) code = HttpStatusCode.Unauthorized;
      else if (ex is BadRequestException) code = HttpStatusCode.BadRequest;

      var result = JsonConvert.SerializeObject(new { error = ex.Message });
      context.Response.ContentType = "application/json";
      context.Response.StatusCode = (int)code;
      return context.Response.WriteAsync(result);
    }

    public class ExceptionLog
    {
      public Exception Exception { get; set; }
      public HttpContext Context { get; set; }
    }
  }
}
