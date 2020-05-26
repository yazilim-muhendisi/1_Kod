using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tekno_egitim_web.API.Data_Transfer_Objects;
using tekno_egitim_web.core.Services;

namespace tekno_egitim_web.API.Filters
{

    public class NotFoundFilter : ActionFilterAttribute
    {
        private readonly IBlogServices _blogservices;
        public NotFoundFilter(IBlogServices blogservices)
        {
            _blogservices = blogservices;
        }
        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int kategori_id = (int) context.ActionArguments.Values.FirstOrDefault();
            var blog = await _blogservices.GetByIdAsync(kategori_id);
            if(blog!= null)
            {
                await next();
            }
            else
            {
                ErrorDto errordto = new ErrorDto();
                errordto.Durum = 404;
                errordto.Error.Add($"id'si {kategori_id} olan blog, veri tabanında bulunamadı");
                context.Result = new NotFoundObjectResult(errordto);
            }
        }


    }
}
