using Acc.Cmd.Domain.DomainObjects;
using Acc.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Acc.Cmd.Infrastructure.EFConfig
{
    public class AccountsConfiguration : IEntityTypeConfiguration<Accounts>
    {
        public void Configure(EntityTypeBuilder<Accounts> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.Accounts_TABLENAME);
            builder.Property(x => x.Code).HasField("_code").HasMaxLength(32).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Type).HasField("_type").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.AccountName).HasField("_accountName").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.PasswordHash).HasField("_passwordHash").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Salt).HasField("_salt").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.TokenKey).HasField("_tokenKey").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ExpiryTimeUTC).HasField("_expiryTimeUTC").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ExpiryTime).HasField("_expiryTime").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.RefreshToken).HasField("_refreshToken").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.UserId).HasField("_userId").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
