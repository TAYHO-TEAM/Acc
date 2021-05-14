using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.Common;


namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class NS_HangMucDetailConfiguration : IEntityTypeConfiguration<NS_HangMucDetail>
    {
        public void Configure(EntityTypeBuilder<NS_HangMucDetail> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.NS_HangMucDetail_TABLENAME);
            builder.Property(x => x.HangMucId).HasField("_hangMucId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ProjectId).HasField("_projectId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.GiaiDoanId).HasField("_giaiDoanId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.GiaTri).HasField("_giaTri").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
