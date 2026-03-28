using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ProductManagement.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            Console.WriteLine($"[ERROR] Exception: {context.Exception.Message}");

            context.Result = new ContentResult
            {
                Content = @"
                    <div style='font-family:Arial; text-align:center; margin-top:100px'>
                        <h2>⚠️ Oops! Something went wrong.</h2>
                        <p style='color:gray'>Please try again later.</p>
                        <a href='/Product' style='color:blue'>← Go Back to Products</a>
                    </div>",
                ContentType = "text/html",
                StatusCode = 500
            };

            context.ExceptionHandled = true;
        }
    }
}