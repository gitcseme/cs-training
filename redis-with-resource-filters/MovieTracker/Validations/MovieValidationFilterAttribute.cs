using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MovieTracker.Models;

namespace MovieTracker.Validations
{
    public class MovieValidationFilterAttribute : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid) {
                context.Result = new BadRequestObjectResult(context.ModelState);
                return;
            }

            var movieModel = context.ActionArguments["MovieCreateViewModel"] as MovieCreateViewModel;
            if (movieModel is null) {
                context.Result = new BadRequestObjectResult(context.ModelState);
                return;
            }

        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }
    }
}