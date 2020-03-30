using System;
using Autofac;
using EFCore.Autofac;
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
            // services.AddScoped<IUnitOfWork, UnitOfWork>();
            // services.AddScoped<IStudentService, StudentService>();
            // services.AddScoped<IStudentRepository, StudentRepository>();
            // 图片
            services.Configure<PictureOptions>(Configuration.GetSection("PictureOptions"));
            // 连接数据库
            services.AddDbContext<EfCoreContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                    p => p.MigrationsAssembly("Models")));
            // 自定义过滤器并捕获全局异常
            services.AddMvc(options => { options.Filters.Add<BaseExceptionAttribute>(); });

            services.AddControllers();

            #region Swagger UI
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1.1.0",
                    Title = "EFCore",
                    Description = "Api Server",
                    Contact = new OpenApiContact { Name = "jinjupeng", Email = "2365697576@qq.com", Url = new Uri("https://github.com/jinjupeng") }
                });
            });
            #endregion

            services.AddHealthChecks();
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
