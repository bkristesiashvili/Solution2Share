using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solution2Share.Middlewares
{
    public sealed class RedirectOptions
    {
        #region PUBLIC PROPERTIES

        public string RegisterCompletionUrl { get; set; }

        public string ErrorHandlerUrl { get; set; }

        #endregion
    }
}
