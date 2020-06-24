using System;
using Autofac;
using EFCore.Autofac;
using EFCore.Core;
using EFCore.Extensions;
using EFCore.Filters;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Models;
using Repository;
using Serilog;
using Service;

namespace EFCore
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
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // 读取图片配置信息
            services.Configure<PictureOptions>(Configuration.GetSection("PictureOptions"));
            // 配置数据库连接信息;如果DBContext和启动程序不在一个程序集，需要指定要迁移的程序集
            services.AddDbContext<EfCoreContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                    p => p.MigrationsAssembly("EFCore")));

            // 扩展类创建静态方法
            services.ServiceConfigure();

            // 注册session
            services.AddDistributedMemoryCache();
            services.AddSession(s =>
            {
                s.Cookie.Name = ".efcore.session";
                s.Cookie.HttpOnly = true; // 防止xss攻击
                s.IdleTimeout = TimeSpan.FromMinutes(30);
            });
            services.AddMvc(config =>
            {
                config.Filters.Add(typeof(UserAuthorizeAttribute));
            });

            //添加cookie认证
            services.AddAuthentication(o =>
            {
                o.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;//使用默认的Scheme认证授权Scheme

            }).AddCookie(o =>
            {
                // 关于Cookie的配置信息请参考：https://www.cnblogs.com/sheldon-lou/p/9545726.html
                // o.Cookie.Domain = ".contoso.com";//设置Cookie的作用域：他的作用域就包括contoso.com,www.contoso.com
                o.LoginPath = "/Home/Index"; //在身份验证的时候判断为“未登录”则跳转到这个页面
                o.LogoutPath = "/Account/LoginOut";//如果要退出登录则跳转到这个页面
                // o.AccessDeniedPath = "/Account/AccessDenied"; //如果已经通过身份验证，但是没有权限访问则跳转到这个页面
                o.Cookie.HttpOnly = true;//设置 cookie 是否是只能被服务器访问，默认 true,为true时通过js脚本将无法读取到cookie信息，这样能有效的防止XSS攻击，窃取cookie内容，这样就增加了cookie的安全性
                o.SlidingExpiration = true;//设置Cookie过期时间为相对时间；也就是说在Cookie设定过期的这个时间内用户没有访问服务器，那么cookie就会过期，若有访问服务器，那么cookie期限将从新设为这个时间
                o.ExpireTimeSpan = TimeSpan.FromDays(1); //设置Cookie过期时间为1天
                o.ClaimsIssuer = "Cookie";//获取或设置应用于创建的任何声明的颁发者
                // o.Cookie.Path = "/app1"; //用来隔离同一个服务器下面的不同站点。比如站点是运行在/app1下面，设置这个属性为/app1，那么这个 cookie 就只在 app1下有效。

            });
        }

        #region AutoFac的DI实现

        // This is the default if you don't have an environment specific method.
        public void ConfigureContainer(ContainerBuilder builder)
        {
            // Add things to the Autofac ContainerBuilder.
            builder.RegisterModule(new AutofacModule());
        }
        #endregion

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider svp)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            #region Swagger
            // 启动中间件服务生成Swagger作为JSON的终结点
            app.UseSwagger();
            // 启用中间件服务对swagger ui，指定Swagger JSON终结点
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiHelp V1");
                // http://localhost:<port>/
                c.RoutePrefix = string.Empty;
            });
            #endregion

            app.UseHealthChecks("/health");

            app.UseSerilogRequestLogging();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            // 注册session中间件
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            MyHttpContext.ServiceProvider = svp;
        }
    }
}
