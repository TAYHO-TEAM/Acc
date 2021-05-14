using ProjectManager.CMD.Domain.DomainObjects;
using Services.Common.APIs.Cmd.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Common;

namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class SysJobTableConfiguration : IEntityTypeConfiguration<SysJobTable>
    {
        public void Configure(EntityTypeBuilder<SysJobTable> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.SysJobTable_TABLENAME);
            builder.Property(x => x.SysJobId).HasField("_sysJobId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.No).HasField("_no").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Name).HasField("_name").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.IsHeader).HasField("_isHeader").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.HeaderColor).HasField("_headerColor").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.HeaderBackGroundColor).HasField("_headerBackGroundColor").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Border).HasField("_border").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Color).HasField("_color").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.BackGroundColor).HasField("_backGroundColor").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.BeginRow).HasField("_beginRow").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.BeginCol).HasField("_beginCol").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Priority).HasField("_priority").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Style).HasField("_style").HasMaxLength(2048).UsePropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
