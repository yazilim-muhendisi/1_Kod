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
        private readonly IHaberServices _haberservices;
        private readonly IMakaleServices _makaleservices;
        private readonly INotServices _notservices;
        private readonly IVideoServices _videoservices;
        public NotFoundFilter(IBlogServices blogservices, IHaberServices haberservices, IMakaleServices makaleservices, INotServices notservices, IVideoServices videoservices)
        {
            _blogservices = blogservices;
            _haberservices = haberservices;
            _makaleservices = makaleservices;
            _notservices = notservices;
            _videoservices = videoservices;
        }
        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int kategori_id = (int) context.ActionArguments.Values.FirstOrDefault();
            var blog = await _blogservices.GetByIdAsync(kategori_id);
            var haber = await _haberservices.GetByIdAsync(kategori_id);
            var makale = await _makaleservices.GetByIdAsync(kategori_id);
            var not = await _notservices.GetByIdAsync(kategori_id);
            var video = await _videoservices.GetByIdAsync(kategori_id);

            if (blog!= null)
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

            if (haber != null)
            {
                await next();
            }
            else
            {
                ErrorDto errordto = new ErrorDto();
                errordto.Durum = 404;
                errordto.Error.Add($"id'si {kategori_id} olan haber, veri tabanında bulunamadı");
                context.Result = new NotFoundObjectResult(errordto);
            }

            if (makale != null)
            {
                await next();
            }
            else
            {
                ErrorDto errordto = new ErrorDto();
                errordto.Durum = 404;
                errordto.Error.Add($"id'si {kategori_id} olan makale, veri tabanında bulunamadı");
                context.Result = new NotFoundObjectResult(errordto);
            }

            if (not != null)
            {
                await next();
            }
            else
            {
                ErrorDto errordto = new ErrorDto();
                errordto.Durum = 404;
                errordto.Error.Add($"id'si {kategori_id} olan not, veri tabanında bulunamadı");
                context.Result = new NotFoundObjectResult(errordto);
            }
            if (video != null)
            {
                await next();
            }
            else
            {
                ErrorDto errordto = new ErrorDto();
                errordto.Durum = 404;
                errordto.Error.Add($"id'si {kategori_id} olan video, veri tabanında bulunamadı");
                context.Result = new NotFoundObjectResult(errordto);
            }

        }


    }
}
