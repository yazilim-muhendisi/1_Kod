using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using tekno_egitim_web.API.Data_Transfer_Objects;
using tekno_egitim_web.API.Extensions;
using tekno_egitim_web.API.Filters;
using tekno_egitim_web.core.Model;
using tekno_egitim_web.core.Repository;
using tekno_egitim_web.core.Services;
using tekno_egitim_web.core.UnitOfWorks;
using tekno_egitim_web.coreproject.KategoriAPI;
using tekno_egitim_web.data;
using tekno_egitim_web.data.Repository;
using tekno_egitim_web.data.UnitOfWork;
using tekno_egitim_web.services.Services;

namespace tekno_egitim_web.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient<KategoriAPIServices>(options =>
            {
                options.BaseAddress = new Uri(Configuration["localhost"]);
            });
            services.AddScoped<NotFoundFilter>();
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IService<>), typeof(services.Services.Service<>));
            services.AddScoped<IKategoriServices, KategoriService>();
            services.AddScoped<IBlogServices, BlogService>();
            services.AddScoped<IHaberServices, HaberService>();
            services.AddScoped<IMakaleServices, MakaleService>();
            services.AddScoped<INotServices, NotService>();
            services.AddScoped<IVideoServices, VideoService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer("Data Source=DESKTOP-JITEBE9;Initial Catalog=ApplicationDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            });
            services.AddMvc()
                   .AddControllersAsServices();
            services.AddControllers().AddControllersAsServices();
            services.AddControllers(o =>
            {
                o.Filters.Add(new ValidationFilter());
            });
            services.Configure<ApiBehaviorOptions>(options => {
                options.SuppressModelStateInvalidFilter = true;
            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            };

            app.UseCustomException();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
