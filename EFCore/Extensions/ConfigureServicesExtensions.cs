using System;
using EFCore.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Models;

namespace EFCore.Extensions
{
	public static class ConfigureServicesExtensions
	{
		public static void ServiceConfigure(this IServiceCollection services)
		{
			#region Core内置IOC
			// services.AddScoped<IUnitOfWork, UnitOfWork>();
			// services.AddScoped<IStudentService, StudentService>();
			// services.AddScoped<IStudentRepository, StudentRepository>();
			#endregion

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
    }
}