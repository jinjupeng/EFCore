using System;
using Exceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Utils;

namespace EFCore.Filters
{
	public class BaseExceptionAttribute : Attribute, IExceptionFilter
	{
		// 记录异常日志
		private readonly ILogger _logger = null;
		// 获取程序运行环境变量
		private readonly IWebHostEnvironment _webHostEnvironment = null;

		public BaseExceptionAttribute(ILogger<BaseExceptionAttribute> logger, IWebHostEnvironment webHostEnvironment)
		{
			this._logger = logger;
			this._webHostEnvironment = webHostEnvironment;
		}

		public void OnException(ExceptionContext filterContext)
		{
			string error = string.Empty;

			void ReadException(Exception ex)
			{
				error += $"{ex.Message} | {ex.StackTrace} | {ex.InnerException}";
				if (ex.InnerException != null)
				{
					ReadException(ex.InnerException);
				}
			}

			ReadException(filterContext.Exception);
			_logger.LogError(error);

			ContentResult result = new ContentResult
			{
				StatusCode = 500,
				ContentType = "text/json;charset=utf-8;"
			};

			if (!filterContext.ExceptionHandled && filterContext.Exception is BaseException)
			{
				BaseException ex = filterContext.Exception as BaseException;

				var json = new ResponseDataHelper
				{
					ResponseCode = ex.ExceptionCode,
					ResponseMessage = ex.ExceptionMessage
				};
				result.Content = JsonConvert.SerializeObject(json);

			}
			else
			{
				var json = new ResponseDataHelper
				{
					ResponseCode = 500,
					ResponseMessage = "发生系统内部错误"
				};
				result.Content = JsonConvert.SerializeObject(json);
			}
			filterContext.Result = result;
			// 异常已经处理了
			filterContext.ExceptionHandled = true;
		}
	}
}