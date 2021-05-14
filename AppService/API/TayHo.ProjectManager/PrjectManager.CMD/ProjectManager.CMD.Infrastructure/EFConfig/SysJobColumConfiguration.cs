using ProjectManager.CMD.Domain.DomainObjects;
using Services.Common.APIs.Cmd.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Common;

namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class SysJobColumConfiguration : IEntityTypeConfiguration<SysJobColum>
    {
        public void Configure(EntityTypeBuilder<SysJobColum> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.SysJobColum_TABLENAME);
            builder.Property(x => x.NoCol).HasField("_noCol").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.SysJobTableId).HasField("_sysJobTableId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Style).HasField("_style").HasMaxLength(1024).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Formulas).HasField("_formulas").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Functions).HasField("_functions").UsePropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
