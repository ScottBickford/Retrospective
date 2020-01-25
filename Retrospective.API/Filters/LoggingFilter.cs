using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IO;

namespace Retrospective.API.Filters
{
  [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
  public class LoggingFilter : ActionFilterAttribute
  {
    // Since this demo users no DB, save the logs in memory for now
    public static List<Log> Logs = new List<Log>();

    public override void OnActionExecuting(ActionExecutingContext context)
    {
      var controller = context.Controller as ControllerBase;
      string requestPath = controller.Request.Path;
      string queryString = controller.Request.QueryString.ToString();
      string method = controller.Request.Method;
      string body = "";

      if (string.Compare(method, "POST") == 0 && controller.Request.Body is Stream)
      {
        controller.Request.Body.Position = 0;
        using (var reader = new StreamReader(controller.Request.Body))
        {
          body = reader.ReadToEnd();
        }
      }

      Logs.Add(new Log
      {
        DateRequested = DateTime.Now,
        RequestPath = requestPath,
        QueryString = queryString,
        Method = method,
        Body = body
      });
    }
  }

  public class Log
  {
    public DateTime DateRequested { get; set; }
    public string RequestPath { get; set; }
    public string QueryString { get; set; }
    public string Method { get; set; }
    public string Parameters { get; set; }
    public string Body { get; set; }
  }
}
