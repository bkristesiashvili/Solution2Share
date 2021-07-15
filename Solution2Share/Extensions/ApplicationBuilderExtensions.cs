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
            string comppleteRegisterLocation)
            => builder.UseMiddleware<RegisterMicrosoftUserMiddleware>(new[] { comppleteRegisterLocation });

        #endregion
    }
}
