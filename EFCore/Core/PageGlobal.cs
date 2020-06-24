using System;
using System.Collections.Generic;
using System.Linq;
using Utils.Extensions;

namespace EFCore.Core
{
    public class PageGlobal
    {
        /// <summary>
        /// 经理职权最高界限
        /// </summary>
        public const decimal ManagerLevel = 6M;
        /// <summary>
        /// 职员职权最高界限
        /// </summary>
        public const decimal StaffLevel = 2M;
        /// <summary>
        /// 存储用户信息的KEY
        /// </summary>
        public const string USER_SESSION_KEY = "_hx_user_session_key";

        /// <summary>
        /// 存储用户权限信息的KEY
        /// </summary>
        public const string USER_POWER_SESSION_KEY = "_hx_user_power_session_key";

        /// <summary>
        /// 存储用户名和密码的KEY
        /// </summary>
        public const string USER_NAME_PWD_COOKIE_KEY = "_hx_user_identify_key";

        /// <summary>
        /// 存储密钥的KEY
        /// </summary>
        public const string USER_PIRVATE_KEY = "hx.user.bid.front";

        /// <summary>
        /// 存储用户令牌
        /// </summary>
        public const string USER_TOKEN_KEY = "_hx_user_user_token_key";

        #region
        private static PageGlobal _current;
        static PageGlobal()
        {
            _current = new PageGlobal();
        }
        private PageGlobal()
        {
        }
        #endregion

        public static PageGlobal Current { get { return _current; } }

        /// <summary>
        /// 用户登录信息
        /// </summary>
        public LoginUser LoginUser
        {
            get
            {
                return MyHttpContext.Current.Session.Get<LoginUser>(USER_SESSION_KEY) as LoginUser;
            }
        }

        /// <summary>
        /// 获得显示的名字，昵称->用户名
        /// </summary>
        /// <returns></returns>
        public string GetShowName()
        {
            if (!string.IsNullOrWhiteSpace(this.LoginUser.UserTrueName))
                return this.LoginUser.UserTrueName;
            return this.LoginUser.UserName.Trim();
        }

        /// <summary>
        /// 获得显示的名字，昵称->用户名
        /// </summary>
        /// <returns></returns>
        public string GetLogName()
        {
            if (!string.IsNullOrWhiteSpace(this.LoginUser.UserTrueName))
                return this.LoginUser.UserTrueName + "(" + this.LoginUser.UserName.Trim() + ")";
            return this.LoginUser.UserName.Trim();
        }

        /// <summary>
        /// 用户是否登录
        /// </summary>
        public bool IsLogin
        {
            get
            {
                return LoginUser != null;
            }
        }

        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserID
        {
            get
            {
                if (IsLogin)
                {
                    return LoginUser.UserId;
                }
                return 0;
            }
        }

        /// <summary>
        /// 设置当前登录用户
        /// </summary>
        /// <param name="loginUser"></param>
        public void SetLoginUser(LoginUser loginUser)
        {
            MyHttpContext.Current.Session.Set(USER_SESSION_KEY, loginUser);
        }

        /// <summary>
        /// 用户是否登录
        /// </summary>
        /// <returns></returns>
        public bool CheckLogin(bool autoRedirect = true)
        {
            return this.IsLogin;
        }

        /// <summary>
        /// 设置用户权限
        /// </summary>
        /// <param name="userPowers">用户权限</param>
        public void SetUserPower(string[] userPowers)
        {
            MyHttpContext.Current.Session.Set(USER_POWER_SESSION_KEY, userPowers);
        }

        /// <summary>
        /// 用户权限
        /// </summary>
        public string[] UserPowers
        {
            get
            {
                return MyHttpContext.Current.Session.Get<string[]>(USER_POWER_SESSION_KEY) as string[];
            }
        }

        /// <summary>
        /// 是否有权限
        /// </summary>
        /// <param name="powerKey"></param>
        /// <returns></returns>
        public bool HasPower(string powerKey)
        {
            return UserPowers.Contains((powerKey ?? "").ToLower());
        }

        /// <summary>
        /// 用户令牌
        /// </summary>
        public string Token
        {
            get
            {
                return MyHttpContext.Current.Session.Get<string>(USER_TOKEN_KEY) as string;
            }
            set
            {
                MyHttpContext.Current.Session.Set(USER_TOKEN_KEY, value); 
            }
        }


        #region 用户权限相关

        static string[] _userPowers
        {
            get
            {
                List<string> userPowers = new List<string>();
                return userPowers.ToArray();
            }
        }

        #endregion
    }

    public class LoginUser
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string UserPass { get; set; }

        public string UserMobile { get; set; }//用户手机号

        public string UserTrueName { get; set; }

        public string RoleName { get; set; }
        public string RoleCode { get; set; }
        public int RoleId { get; set; }


    }
}
