using System;
using Autofac;
using EFCore.Autofac;
using EFCore.Extensions;
using EFCore.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
            // 读取图片配置信息
            services.Configure<PictureOptions>(Configuration.GetSection("PictureOptions"));
            // 配置数据库连接信息
            services.AddDbContext<EfCoreContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                    p => p.MigrationsAssembly("Models")));

            // 扩展类创建静态方法
            services.ServiceConfigure();
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
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
