using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.Common;


namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class NS_KhauTruConfiguration : IEntityTypeConfiguration<NS_KhauTru>
    {
        public void Configure(EntityTypeBuilder<NS_KhauTru> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.NS_KhauTru_TABLENAME);
            builder.Property(x => x.GoiThauId).HasField("_goiThauId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ProjectId).HasField("_projectId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.NoiDung).HasField("_noiDung").HasMaxLength(500).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.DienGiai).HasField("_dienGiai").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.GiaTri).HasField("_giaTri").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.GiaTriCon).HasField("_giaTriCon").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
