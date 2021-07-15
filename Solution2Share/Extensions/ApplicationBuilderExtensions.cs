using Microsoft.AspNetCore.Builder;

using Solution2Share.Middlewares;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solution2Share.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        #region EXTENSION METHODS

        public static IApplicationBuilder UseRegisterMicrosoftUser(this IApplicationBuilder builder,
            Action<RedirectOptions> action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            RedirectOptions option = new RedirectOptions();

            action.Invoke(option);

           return builder.UseMiddleware<RegisterMicrosoftUserMiddleware>(new[] { option });
        }

        #endregion
    }
}
