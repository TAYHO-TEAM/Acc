using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OperationManager.CRUD.Common;
using OperationManager.CRUD.DAL.DTO.ProjectManagerDTO;

namespace OperationManager.CRUD.DAL.EFConfig
{
    public class SysJobColumConfiguration
    {
        public void Configure(EntityTypeBuilder<SysJobColum> builder)
        {
            builder.ToTable(ProjectManagerConstants.SysJobColum_TABLENAME);
           builder.Property(x => x.Code).HasColumnName("Code").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
	builder.Property(x => x.Barcode).HasColumnName("Barcode").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.NoCol).HasColumnName("NoCol").UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.SysJobTableId).HasColumnName("SysJobTableId").UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.Style).HasColumnName("Style").HasMaxLength(1024).UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.Formulas).HasColumnName("Formulas").UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.Functions).HasColumnName("Functions").UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.Border).HasColumnName("Border").UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.Color).HasColumnName("Color").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.BackGroundColor).HasColumnName("BackGroundColor").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
			
        }
    }
}
