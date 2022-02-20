using DomainDTO.OutPutModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Permission_API.Filters
{
    /// <summary>
    /// 自定义行为过滤器 ation ActionFilterAttribute就是过滤器action
    /// </summary>
    public class CustomActtionFilter: ActionFilterAttribute
    {
        /// <summary>
        /// 执行时拦截
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var filterModels = new OutPutFiltersResultModels();
            if (!context.ModelState.IsValid)
            {
                //   context.
                foreach (var value in context.ModelState.Values)
                {
                    foreach (var error in value.Errors)
                    {
                        filterModels.Message += error.ErrorMessage + "|";
                    }
                }
                filterModels.Code = "400";
                context.Result = new JsonResult(filterModels);
            }
         
            base.OnActionExecuting(context);
        }
    }
}
