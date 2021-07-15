using Microsoft.AspNetCore.Identity;
using Microsoft.Graph;
using Microsoft.Identity.Web;

using Solution2Share.Data.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution2Share.Service
{
    public interface IUserService
    {
        #region INTERFACE PROPERTIES

        UserManager<Data.Entities.User> UserManager { get; }

        SignInManager<Data.Entities.User> SigninManager { get; }

        IGraphServiceClient GraphClient { get; }

        ITokenAcquisition TokenAcquisition { get; }

        GraphOption Options { get; }

        #endregion

        #region INTERFACE METHODS

        void InitializeGraphClient(GraphOption option);

        #endregion
    }
}
