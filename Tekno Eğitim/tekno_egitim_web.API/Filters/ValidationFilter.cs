using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tekno_egitim_web.API.Data_Transfer_Objects;

namespace tekno_egitim_web.API.Filters
{
    public class ValidationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
           if(!context.ModelState.IsValid)
            {
                ErrorDto errordto = new ErrorDto();
                errordto.Durum = 400;
                IEnumerable <ModelError> modelerror = context.ModelState.Values.SelectMany(v => v.Errors);

                modelerror.ToList().ForEach(x => { errordto.Error.Add(x.ErrorMessage); });
                context.Result = new BadRequestObjectResult(errordto);
            }
        }
    }
}
