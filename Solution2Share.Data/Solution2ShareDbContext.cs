﻿using Microsoft.EntityFrameworkCore;

using Solution2Share.Data.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution2Share.Data
{
    public sealed class Solution2ShareDbContext : DbContext
    {
        #region CTOR

        public Solution2ShareDbContext(DbContextOptions<Solution2ShareDbContext> options)
            : base(options) { }

        #endregion

        #region DBSETS

        public DbSet<MicrosoftUser> MicrosoftUsers { get; set; }

        #endregion

        #region OVERRIDE METHODS

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MicrosoftUserEntityConfig());
            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}
