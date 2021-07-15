using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Solution2Share.Data.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution2Share.Data
{
    public sealed class Solution2ShareDbContext
        : IdentityDbContext<User, Role, Guid>
    {
        #region CTOR

        public Solution2ShareDbContext(DbContextOptions<Solution2ShareDbContext> option)
            : base(option) { }

        #endregion
    }
}
