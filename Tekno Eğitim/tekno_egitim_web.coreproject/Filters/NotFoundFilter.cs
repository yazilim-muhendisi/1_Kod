using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tekno_egitim_web.core.Services;
using tekno_egitim_web.coreproject.Data_Transfer_Objects;

namespace tekno_egitim_web.coreproject.Filters
{

    public class NotFoundFilter : ActionFilterAttribute
    {
        private readonly IKategoriServices _kategoriservices;
        public NotFoundFilter(IKategoriServices kategoriservices)
        {
                _kategoriservices = kategoriservices;
        }
        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int blog_id = (int) context.ActionArguments.Values.FirstOrDefault();
            var blog = await _kategoriservices.GetByIdAsync(blog_id);
            if(blog!= null)
            {
                await next();
            }
            else
            {
                ErrorDto errordto = new ErrorDto();
                errordto.Durum = 404;
                errordto.Error.Add($"id'si {blog_id} olan kategori, veri tabanında bulunamadı");
                context.Result = new RedirectToActionResult("Error", "Home", errordto);
            }
        }


    }
}
