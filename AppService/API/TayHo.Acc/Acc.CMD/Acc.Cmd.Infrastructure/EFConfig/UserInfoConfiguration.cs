using Acc.Cmd.Domain.DomainObjects;
using Acc.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Acc.Cmd.Infrastructure.EFConfig
{
    public class UserInfoConfiguration : IEntityTypeConfiguration<UserInfo>
    {
        public void Configure(EntityTypeBuilder<UserInfo> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.UserInfo_TABLENAME);
            builder.Property(x => x.AvatarImg).HasField("_avatarImg").HasMaxLength(1028).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.FirstName).HasField("_firstName").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.LastName).HasField("_lastName").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Sex).HasField("_sex").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.DateOfBirth).HasField("_dateOfBirth").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Country).HasField("_country").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.City).HasField("_city").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.District).HasField("_district").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Address).HasField("_address").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Phone).HasField("_phone").HasMaxLength(15).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Email).HasField("_email").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
