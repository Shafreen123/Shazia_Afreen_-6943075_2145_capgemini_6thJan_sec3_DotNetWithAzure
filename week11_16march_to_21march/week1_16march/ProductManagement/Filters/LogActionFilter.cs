using Microsoft.AspNetCore.Mvc.Filters;

namespace ProductManagement.Filters
{
    public class LogActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = context.RouteData.Values["controller"];
            var action = context.RouteData.Values["action"];

            Console.WriteLine("╔════════════════════════════════════════════");
            Console.WriteLine($"║ ACTION START : {controller}/{action}");
            Console.WriteLine($"║ TIME         : {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine("╚════════════════════════════════════════════");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var controller = context.RouteData.Values["controller"];
            var action = context.RouteData.Values["action"];

            Console.WriteLine($"[LOG] ✔ Completed: {controller}/{action} at {DateTime.Now:HH:mm:ss}");
            Console.WriteLine(new string('-', 50));
        }
    }
}