using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace Web.Infrastructure
{
    public class ModelStateValidationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                // for api 
                //context.Result = new BadRequestObjectResult(context.ModelState);

                // for web view
                object model = context.ActionArguments.Any() ? context.ActionArguments.First().Value : null;
                context.Result = (context.Controller as Controller)?.View(model);
            }

            base.OnActionExecuting(context);
        }
    }
}
