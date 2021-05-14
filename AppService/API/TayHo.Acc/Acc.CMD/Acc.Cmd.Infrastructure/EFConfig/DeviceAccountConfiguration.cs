using Acc.Cmd.Domain.DomainObjects;
using Acc.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Acc.Cmd.Infrastructure.EFConfig
{
    public class DeviceAccountConfiguration : IEntityTypeConfiguration<DeviceAccount>
    {
        public void Configure(EntityTypeBuilder<DeviceAccount> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.DeviceAccount_TABLENAME);
            builder.Property(x => x.Device).HasField("_device").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.AccountId).HasField("_accountId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.DeviceToken).HasField("_deviceToken").HasMaxLength(1024).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Browser).HasField("_browser").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
