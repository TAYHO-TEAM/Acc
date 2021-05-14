using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class ContractorInfoConfiguration : IEntityTypeConfiguration<ContractorInfo>
    {
        public void Configure(EntityTypeBuilder<ContractorInfo> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.ContractorInfo_TABLENAME);
            builder.Property(x => x.Code).HasField("_code").HasMaxLength(32).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.TaxCode).HasField("_taxCode").HasMaxLength(64).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.AvatarImg).HasField("_avatarImg").HasMaxLength(1024).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Name).HasField("_name").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Descriptions).HasField("_descriptions").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.BusinessAreas).HasField("_businessAreas").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Country).HasField("_country").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.City).HasField("_city").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.District).HasField("_district").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Address).HasField("_address").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Phone).HasField("_phone").HasMaxLength(32).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Email).HasField("_email").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
