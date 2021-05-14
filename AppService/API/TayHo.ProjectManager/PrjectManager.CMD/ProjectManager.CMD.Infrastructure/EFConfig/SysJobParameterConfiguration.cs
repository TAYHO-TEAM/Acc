using ProjectManager.CMD.Domain.DomainObjects;
using Services.Common.APIs.Cmd.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Common;

namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class SysJobParameterConfiguration : IEntityTypeConfiguration<SysJobParameter>
    {
        public void Configure(EntityTypeBuilder<SysJobParameter> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.SysJobParameter_TABLENAME);
            builder.Property(x => x.SysJobId).HasField("_sysJobId").HasMaxLength(10).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Name).HasField("_name").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.DisplayName).HasField("_displayName").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.DataTypeSQL).HasField("_dataTypeSQL").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.DataTypeC).HasField("_dataTypeC").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.DefaultValue).HasField("_defaultValue").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
