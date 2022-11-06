using Demo.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.RegularExpressions;

namespace Demo.Filter
{
    public class TypeValidtion : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var TypeRegex = new Regex("^(Elctric|Gaz|Disel|Hybrid)$");
          Car?  car = context.ActionArguments["Obj"] as Car;

            if(car is null || TypeRegex.IsMatch(car.Type))
            {
                context.Result = new BadRequestObjectResult(new { Error = "Type IS valid" });
            }
            
        }
    }
}
