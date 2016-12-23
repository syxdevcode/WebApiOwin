using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiOwin.App_Start;
using WebApiOwin.Provider;

namespace WebApiOwin
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            var OAuthOptions = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                AuthenticationMode = AuthenticationMode.Active,
                TokenEndpointPath = new PathString("/token"), //获取 access_token 认证服务请求地址
                AuthorizeEndpointPath = new PathString("/authorize"), //获取 authorization_code 认证服务请求地址
                AccessTokenExpireTimeSpan = TimeSpan.FromSeconds(10), //access_token 过期时间

                Provider = IocContainer.Instance.Resolve<CNBlogsAuthorizationServerProvider>(),
                RefreshTokenProvider = IocContainer.Resolver.Resolve<CNBlogsRefreshTokenProvider>()

                #region 授权码模式（authorization code）
                /*
                Provider = new OpenAuthorizationCodeServerProvider(), //access_token 相关认证服务
                AuthorizationCodeProvider = new OpenAuthorizationCodeProvider(), //authorization_code 认证服务
                RefreshTokenProvider = new OpenRefreshTokenProvider() //refresh_token 认证服务
                */
                #endregion

                #region 密码模式（resource owner password credentials）
                /*
                Provider = new OpenAuthorizationPasswdServerProvider(), //access_token 相关认证服务
                RefreshTokenProvider = new OpenRefreshTokenProvider() //refresh_token 认证服务
                */
                #endregion

                #region 客户端模式（Client Credentials Grant）
                /*
                Provider = new OpenAuthorizationClientGrantServerProvider(), //access_token 相关认证服务
                RefreshTokenProvider = new OpenRefreshTokenProvider() //refresh_token 认证服务
                */
                #endregion

                #region 简化模式（implicit grant type）
                /*
                Provider = new OpenAuthorizationCodeServerProvider(), //access_token 相关认证服务
                RefreshTokenProvider = new OpenRefreshTokenProvider() //refresh_token 认证服务
                */
                #endregion
            };
            app.UseOAuthBearerTokens(OAuthOptions); //表示 token_type 使用 bearer 方式
        }
    }
}