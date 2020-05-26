using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tekno_egitim_web.coreproject.Data_Transfer_Objects;

namespace tekno_egitim_web.coreproject.Extensions
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomException( this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";
                    var error = context.Features.Get<IExceptionHandlerFeature>();

                    if (error != null)
                    {
                        var ex = error.Error;

                        ErrorDto errordto = new ErrorDto();
                        errordto.Durum = 500;
                        errordto.Error.Add(ex.Message);

                        await context.Response.WriteAsync(JsonConvert.SerializeObject(errordto));
                    }
                });
            });
        }
    }
}
