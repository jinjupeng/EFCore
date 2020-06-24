using System;
using Microsoft.AspNetCore.Http;

namespace EFCore.Core
{
    public static class MyHttpContext
    {
        public static IServiceProvider ServiceProvider;

        public static HttpContext Current
        {
            get
            {
                object factory = ServiceProvider.GetService(typeof(IHttpContextAccessor));
                HttpContext context = ((IHttpContextAccessor)factory).HttpContext;
                return context;
            }
        }

    }
}
