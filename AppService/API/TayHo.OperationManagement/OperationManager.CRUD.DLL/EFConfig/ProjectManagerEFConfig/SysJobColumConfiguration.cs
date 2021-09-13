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
            builder.Property(x => x.SysJobTableId).HasColumnName("SysJobTableId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.IsAutoFit).HasColumnName("IsAutoFit").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.NoCol).HasColumnName("NoCol").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Style).HasColumnName("Style").HasMaxLength(1024).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Formulas).HasColumnName("Formulas").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Functions).HasColumnName("Functions").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Border).HasColumnName("Border").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Color).HasColumnName("Color").HasMaxLength(1024).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ColSpan).HasColumnName("ColSpan").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.RowSpan).HasColumnName("RowSpan").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.FontStyleId).HasColumnName("FontStyleId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.FontId).HasColumnName("FontId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.FontSize).HasColumnName("FontSize").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.BackGroundStyleId).HasColumnName("BackGroundStyleId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.BackGroundColorId).HasColumnName("BackGroundColorId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.VerticalAlignment).HasColumnName("VerticalAlignment").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.HorizontalAlignment).HasColumnName("HorizontalAlignment").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.IsWrapText).HasColumnName("IsWrapText").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Width).HasColumnName("Width").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Height).HasColumnName("Height").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
