using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.Common;


namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class NS_HangMucConfiguration : IEntityTypeConfiguration<NS_HangMuc>
    {
        public void Configure(EntityTypeBuilder<NS_HangMuc> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.NS_HangMuc_TABLENAME);
            builder.Property(x => x.ParentId).HasField("_parentId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.TenHangMuc).HasField("_tenHangMuc").HasMaxLength(500).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.KyHieu).HasField("_kyHieu").HasMaxLength(50).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ProjectId).HasField("_projectId").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
