using Microsoft.AspNetCore.Http;

using Solution2Share.Service;

using System.Threading.Tasks;

namespace Solution2Share.Middlewares;

public class RegisterMicrosoftUserMiddleware
{
    #region PRIVATE FIELDS

    private readonly RequestDelegate _next;
    private readonly RedirectOptions _redirectUrls;

    #endregion

    #region CTOR

    public RegisterMicrosoftUserMiddleware(RequestDelegate next, RedirectOptions options)
    {
        _next = next;
        _redirectUrls = options;
    }

    #endregion

    #region PUBLIC METHODS

    public async Task Invoke(HttpContext httpContext)
    {
        var path = httpContext.Request.Path;

        if (path == _redirectUrls.RegisterCompletionUrl)
        {
            await _next(httpContext);
            return;
        }

        if(path == _redirectUrls.ErrorHandlerUrl)
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
            httpContext.Response.Redirect(_redirectUrls.RegisterCompletionUrl);
    }

    #endregion
}
