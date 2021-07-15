using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

using Solution2Share.Service;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solution2Share.Middlewares
{
    public class RegisterMicrosoftUserMiddleware
    {
        #region PRIVATE FIELDS

        private readonly RequestDelegate _next;
        private readonly string _completeRegistration;

        #endregion

        #region CTOR

        public RegisterMicrosoftUserMiddleware(RequestDelegate next, string completeRegister)
        {
            _next = next;
            _completeRegistration = completeRegister;
        }

        #endregion

        #region PUBLIC METHODS

        public async Task Invoke(HttpContext httpContext)
        {
            var path = httpContext.Request.Path;

            if (path == _completeRegistration)
            {
                await _next(httpContext);
                return;
            }

            var userService = httpContext.RequestServices
                .GetService(typeof(IUserService)) as IUserService;

            await userService.RegistereNewUser();

            if (userService.IsCompletedAccount)
                await _next(httpContext);
            else
                httpContext.Response.Redirect(_completeRegistration);
        }

        #endregion
    }
}
