using Acc.Cmd.Domain.DomainObjects;
using Acc.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Acc.Cmd.Infrastructure.EFConfig
{
    public class StaffTayHoConfiguration : IEntityTypeConfiguration<StaffTayHo>
    {
        public void Configure(EntityTypeBuilder<StaffTayHo> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.StaffTayHo_TABLENAME);
            builder.Property(x => x.UserName).HasField("_userName").HasMaxLength(200).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.AccountName).HasField("_accountName").HasMaxLength(50).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Title).HasField("_title").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.AvatarImg).HasField("_avatarImg").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
