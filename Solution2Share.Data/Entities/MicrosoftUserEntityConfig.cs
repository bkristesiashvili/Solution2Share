using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution2Share.Data.Entities
{
    public sealed class MicrosoftUserEntityConfig : IEntityTypeConfiguration<MicrosoftUser>
    {
        #region PUBLIC IMPLEMENTED CONFIGURE METHOD

        public void Configure(EntityTypeBuilder<MicrosoftUser> builder)
        {
            builder.ToTable("microsoft_users");

            builder.HasKey(user => user.Id);

            builder.HasIndex(user => user.Email)
                   .IsUnique();

            builder.Property(user => user.DisplayName)
                   .IsRequired();

            builder.Property(user => user.CompanyName)
                   .IsRequired();

            builder.Property(user => user.Department)
                   .IsRequired();

            builder.Property(user => user.TenantId)
                   .HasDefaultValue(Guid.Empty);

            builder.Property(user => user.IsActive)
                   .HasDefaultValue(false)
                   .ValueGeneratedOnAdd()
                   .IsRequired();

            builder.Property(user => user.RegisteredAt)
                   .HasDefaultValueSql("GETUTCDATE()");
        }

        #endregion
    }
}
