using Microsoft.Identity.Web;

using Solution2Share.Data;

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

        Solution2ShareDbContext DbContext { get; }

        bool IsCompletedAccount { get; }

        #endregion

        #region INTERFACE METHODS

        Task RegistereNewUser();

        Task CompleteRegistration(Guid existedUser, string company,
            string department, string roleName);

        #endregion
    }
}
