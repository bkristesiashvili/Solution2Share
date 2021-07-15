using Microsoft.AspNetCore.Identity;
using Microsoft.Graph;
using Microsoft.Identity.Web;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution2Share.Service
{
    public sealed class UserService : IUserService
    {
        #region PUBLIC IMPLEMENTED PROPERTIES

        public UserManager<Data.Entities.User> UserManager { get; }

        public SignInManager<Data.Entities.User> SigninManager { get; }

        public IGraphServiceClient GraphClient { get; private set; }

        public ITokenAcquisition TokenAcquisition { get; }

        public GraphOption Options { get; }

        #endregion

        #region CTOR

        public UserService(UserManager<Solution2Share.Data.Entities.User> userManager,
            SignInManager<Solution2Share.Data.Entities.User> signInManager,
            ITokenAcquisition tokenAcquisition)
        {
            SigninManager = signInManager;
            UserManager = userManager;
            TokenAcquisition = tokenAcquisition;
        }

        #endregion

        #region PUBLIC IMPLEMENTED METHODS

        public void InitializeGraphClient(GraphOption option)
        {
            if (option == null)
                throw new ArgumentNullException(nameof(option));

            GraphClient = GraphServiceFactory.GetAuthenticatedClient(async ()
                => await TokenAcquisition.GetAccessTokenForUserAsync(GraphScopes.Scopes)
                , option.ApiUrl);
        }

        #endregion
    }
}
