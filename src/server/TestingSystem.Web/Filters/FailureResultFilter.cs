using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TestingSystem.Application.Common;

namespace TestingSystem.Web.Filters;

public class FailureResultFilter : IResultFilter
{
    public void OnResultExecuting(ResultExecutingContext context)
    {
        if (context.Result is ObjectResult { Value: IOperationResult { Failure: {} failure } })
        {
            context.HttpContext.Response.StatusCode = (int)failure.StatusCode;
        }
    }

    public void OnResultExecuted(ResultExecutedContext context)
    {
    }
}
