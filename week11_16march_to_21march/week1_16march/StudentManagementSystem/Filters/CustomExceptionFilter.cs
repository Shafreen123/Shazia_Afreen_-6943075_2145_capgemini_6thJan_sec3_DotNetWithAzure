using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace StudentManagementSystem.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            Console.WriteLine($"[ERROR] {context.Exception.Message}");

            context.Result = new ContentResult
            {
                Content = @"
                    <div style='font-family:Arial;text-align:center;margin-top:100px'>
                        <h2>⚠️ Oops! Something went wrong.</h2>
                        <p style='color:gray'>Please try again later.</p>
                        <a href='/' style='color:blue'>← Go Back to Home</a>
                    </div>",
                ContentType = "text/html",
                StatusCode = 500
            };

            context.ExceptionHandled = true;
        }
    }
}