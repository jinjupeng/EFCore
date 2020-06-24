using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EFCore.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class UserAuthorizeAttribute : ActionFilterAttribute, IFilterMetadata
    {
        /// <summary>
        /// 授权级别
        /// </summary>
        public AuthorizeLevel Level { get; set; }

        /// <summary>
        /// 权限标识 此值只对授权级别为High时有效，如未设置该值，将默认为[Area.]Controller.Action
        /// </summary>
        public string PowerKey { get; set; }


        /// <summary>
        /// 使用指定的授权级别对操作进行授权
        /// 当授权级别为中级以上时
        /// 
        /// </summary>
        /// <param name="level">授权级别</param>
        public UserAuthorizeAttribute(AuthorizeLevel level)

        {
            this.Level = level;
        }

        /// <summary>
        /// 使用默认级别（低）对操作进行授权
        /// 此时系统会检测用户是否能够进行正常的登录操作（请求中附加有Token参数）但并不会将用户
        /// 自动重定向到登录页面（如果用户未登录）
        /// </summary>
        public UserAuthorizeAttribute()
            : this(AuthorizeLevel.Low)
        {

        }

        /// <summary>
        /// 使用指定的权限标识对操作进行最高级别的授权
        /// 在用户处于未登录状态时将会自动重定向到登录页面
        /// </summary>
        /// <param name="powerKey">权限标识</param>
        public UserAuthorizeAttribute(string powerKey)
            : this(AuthorizeLevel.High)
        {
            this.PowerKey = powerKey;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string powerKey = this.PowerKey;

        }

        /// <summary>
        /// 判断是否登录
        /// </summary>
        /// <param name="filterContext"></param>
        /// <param name="level"></param>
        private bool CheckLogin(ActionExecutingContext filterContext)
        {
            return true;
        }
    }
    /// <summary>
    /// 用户授权级别
    /// </summary>
    public enum AuthorizeLevel : int
    {
        /// <summary>
        /// 低 用户无需登录既可访问该操作
        /// </summary>
        Low,
        /// <summary>
        /// 中 用户需要登录才能访问该操作
        /// </summary>
        Middle,
        /// <summary>
        /// 高 用户需要登录并拥有该资源的访问权限才能进行操作
        /// </summary>
        High
    }
}
