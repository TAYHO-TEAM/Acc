using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.Common;


namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class NS_ReasonConfiguration : IEntityTypeConfiguration<NS_Reason>
    {
        public void Configure(EntityTypeBuilder<NS_Reason> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.NS_Reason_TABLENAME);
            builder.Property(x => x.Ten).HasField("_ten").HasMaxLength(500).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.DienGiai).HasField("_dienGiai").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
