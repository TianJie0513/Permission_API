using DomainDTO.EFTables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Permission_API.Controllers
{
    public class CustomResultFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                ResponseDto result = new DomainDTO.EFTables.ResponseDto() {  data = false };

                foreach (var item in context.ModelState.Values)
                {
                    foreach (var error in item.Errors)
                    {
                        result.message += error.ErrorMessage + "|";
                    }
                }

                context.Result = new JsonResult(result);
            }
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}
