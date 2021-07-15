using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Solution2Share.Service;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solution2Share.Extensions
{
    public static class ServiceCollectionExtensions
    {
        #region EXTENSION METHODS

        public static IServiceCollection AddGraphOptions(this IServiceCollection Services,
            IConfiguration Configuration)
        {
            if (Services == null)
                throw new ArgumentNullException(nameof(Services));

            if (Configuration == null)
                throw new ArgumentNullException(nameof(Configuration));

            Services.Configure<GraphOption>(Configuration);

            return Services;
        }

        #endregion
    }
}
