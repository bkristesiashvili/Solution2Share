using Solution2Share.Data;
using Solution2Share.Data.Entities;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Solution2Share.Service;

public interface IUserService
{
    #region INTERFACE PROPERTIES

    Solution2ShareDbContext DbContext { get; }

    bool IsCompletedAccount { get; }

    #endregion

    #region INTERFACE METHODS

    Task RegistereNewUser();

    Task CompleteRegistration(string company,
        string department, string roleName);

    Task<IEnumerable<MicrosoftUser>> GetAllUsers();

    #endregion
}
