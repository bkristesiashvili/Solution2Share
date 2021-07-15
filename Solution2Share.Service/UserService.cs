﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Web;

using Solution2Share.Data;
using Solution2Share.Data.Entities;
using Solution2Share.Service.Extensions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution2Share.Service
{
    public sealed class UserService : IUserService
    {
        #region PRIVATE FIELDS

        private readonly IHttpContextAccessor ContextAccessor;

        #endregion

        #region PUBLIC PROPERTIES

        public Solution2ShareDbContext DbContext { get; }

        public bool IsCompletedAccount { get; private set; }

        #endregion

        #region CTOR

        public UserService(
            Solution2ShareDbContext dbContext,
            IHttpContextAccessor contextAccessor)
        {
            DbContext = dbContext;
            ContextAccessor = contextAccessor;
        }

        #endregion

        #region PUBLIC METHODS

        public async Task RegistereNewUser()
        {
            var userMail = ContextAccessor
                .HttpContext
                .User
                .GetUserGraphEmail();

            if (string.IsNullOrWhiteSpace(userMail)) return;

            var existed = DbContext.MicrosoftUsers
                .Where(user => user.Email.Equals(userMail))
                .SingleOrDefault();

            if (existed == null)
            {
                DbContext.MicrosoftUsers.Add(new MicrosoftUser
                {
                    DisplayName = ContextAccessor.HttpContext.User.GetUserGraphDisplayName(),
                    Email = userMail,
                    CompanyName = string.Empty,
                    Department = string.Empty,
                    RoleName = string.Empty,
                    TenantId = ContextAccessor.HttpContext.User.GetUserGraphTenant(),
                    IsActive = false
                });

                var result = await DbContext.SaveChangesAsync();

                if (result <= 0)
                    throw new InvalidOperationException();
            }

            IsCompletedAccount = existed != null && existed.IsActive;
        }

        public async Task CompleteRegistration(Guid existedUser, string company, 
            string department, string roleName)
        {
            var existed = await DbContext.MicrosoftUsers
                .Where(user => user.Id.Equals(existedUser))
                .SingleOrDefaultAsync();

            if (existed == null) return;

            existed.CompanyName = company;
            existed.Department = department;
            existed.RoleName = roleName;
            existed.IsActive = true;

            DbContext.MicrosoftUsers.Update(existed);
            await DbContext.SaveChangesAsync();
        }

        #endregion
    }
}
