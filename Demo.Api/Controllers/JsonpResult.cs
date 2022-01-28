using System.Buffers;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

public class JsonpResult : ActionResult
{
    private readonly object _result;

    public JsonpResult(object result)
    {
        _result = result;
    }

    public override void ExecuteResult(ActionContext context)
    {
        var callback = context.HttpContext.Request.Query["callback"].ToString();
        if (!string.IsNullOrEmpty(callback))
        {
            context.HttpContext.Response.BodyWriter.Write(
                Encoding.UTF8.GetBytes($"{callback}({JsonSerializer.Serialize(_result)})"));

            return;
        }

        context.HttpContext.Response.Headers["Content-Type"] = "application/json";
        context.HttpContext.Response.BodyWriter.Write(
            Encoding.UTF8.GetBytes(JsonSerializer.Serialize(_result)));
    }
}