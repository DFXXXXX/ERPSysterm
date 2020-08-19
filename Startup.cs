using System;
using System.IO;
using System.Text;
using ERPSysterm.Filters;
using ERPSysterm.MiddleWare;
using ERPSysterm.Models;
using ERPSysterm.Utility;
using log4net;
using log4net.Config;
using log4net.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace ERPSysterm
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                  .AddJwtBearer(options => {
                      options.TokenValidationParameters = new TokenValidationParameters
                      {
                          ValidateIssuer = true,//是否验证Issuer
                          ValidateAudience = true,//是否验证Audience
                          ValidateLifetime = true,//是否验证失效时间
                          ClockSkew = TimeSpan.FromSeconds(30),
                          ValidateIssuerSigningKey = true,//是否验证SecurityKey
                          ValidAudience = Const.Domain,//Audience
                          ValidIssuer = Const.Domain,//Issuer，这两项和前面签发jwt的设置一致
                          IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Const.SecurityKey))//拿到SecurityKey
                      };
                  });
            Log4netHelper.Repository = LogManager.CreateRepository("NETCoreRepository");
            XmlConfigurator.Configure(Log4netHelper.Repository, new FileInfo(Environment.CurrentDirectory + "/Config/log4net.config"));

            services.AddControllers(options =>
            {
                options.Filters.Add(typeof(WebApiResultMiddleware));
                options.Filters.Add(typeof(MyExceptionFilterAttribute));
                options.Filters.Add(typeof(ApiLogFilter));
                options.RespectBrowserAcceptHeader = true;
            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCustomException(
                new CustomExceptionMiddleWareOption(
                 handleType: CustomExceptionHandleType.JsonHandle //根据url关键字决定处理方式
                ));
            app.UseAuthentication();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
