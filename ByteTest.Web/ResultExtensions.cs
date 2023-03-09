using System.Net;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace ByteTest.Web;

public static class ResultExtensions
{
    public static IActionResult ToResponse<T>(this Result<T> result)
    {
        if (result.IsSuccess)
        {
            return new JsonResult(result.ValueOrDefault){ StatusCode = (int)HttpStatusCode.OK };
        }

        return new JsonResult(result.Errors.Select(x=> x.Message)){ StatusCode = (int)HttpStatusCode.BadRequest };
    }
    
    public static IActionResult ToResponse(this Result result)
    {
        if (result.IsSuccess)
        {
            return new JsonResult(true){ StatusCode = (int)HttpStatusCode.OK };
        }

        return new JsonResult(result.Errors.Select(x=> x.Message)){ StatusCode = (int)HttpStatusCode.BadRequest };
    }
}