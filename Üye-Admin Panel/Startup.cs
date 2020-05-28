using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApp.CustomValidation;
using WebApp.Models;

namespace WebApp
{
    public class Startup
    {
        public IConfiguration configuration { get; } //configuration s?n?f? sayesinde appsettings.json a eri?ebilecek(connection string için)
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppIdentityDbContext>(opts =>
            {
                opts.UseSqlServer(configuration["ConnectionStrings:DefaultConnectionString"]);

            });

            CookieBuilder cookieBuilder = new CookieBuilder();
            cookieBuilder.Name = "AdminBlog";
            cookieBuilder.HttpOnly = false;
            cookieBuilder.Expiration = System.TimeSpan.FromDays(60);
            cookieBuilder.SameSite = SameSiteMode.Lax;
            cookieBuilder.SecurePolicy = CookieSecurePolicy.SameAsRequest;

            services.ConfigureApplicationCookie(opts =>
            {
                opts.LoginPath = new PathString("/Home/Login");// BURAYI UNUTMA ÇÜNKÜ D??ER S?TE ?LE B?RLE??NCE BURAYI KULLANACAKSIN.
                opts.Cookie = cookieBuilder;
                opts.SlidingExpiration = true;
            });



            services.AddIdentity<AppUser, AppRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
                opts.User.AllowedUserNameCharacters = "abcçdefgh?ijklmnopqrs?tuüvwxyzABCÇDEFGHI?JKLMNOPQRS?TUÜVWXYZ0123456789-._";

                opts.Password.RequiredLength = 4;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;


            }).AddPasswordValidator<CustomPasswordValidator>()
            .AddUserValidator<CustomUserValidator>()
            .AddErrorDescriber<CustomIdentityErrorDescriber>()
            .AddEntityFrameworkStores<AppIdentityDbContext>();


            services.AddMvc(); //uygulamayla ilgili(mvc) tüm servisleri aya?a kald?r?r.
            services.AddMvc(options => options.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage(); //sayfada hata ald???m?zda aç?klay?c? bilgiler sunar.
            app.UseStatusCodePages(); //herhangi bir içerik bir content olmayan sayfalarda bize aç?klay?c? bilgi sunuyor.
            //Yani bo? bir sayfa görmek yerine hatan?n nerde oldu?unu gösteren yaz? dönüyor.
            app.UseStaticFiles();//javascript css dosyalar?n? eklemeye yard?mc? olur.
            app.UseMvcWithDefaultRoute(); //Controller-Actions{id}
            app.UseAuthentication(); //identity için authentication yap?s?


        }
    }
}
