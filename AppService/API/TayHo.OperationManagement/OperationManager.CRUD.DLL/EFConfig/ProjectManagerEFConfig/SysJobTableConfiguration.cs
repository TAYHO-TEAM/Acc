using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OperationManager.CRUD.Common;
using OperationManager.CRUD.DAL.DTO.ProjectManagerDTO;

namespace OperationManager.CRUD.DAL.EFConfig
{
    public class SysJobTableConfiguration
    {
        public void Configure(EntityTypeBuilder<SysJobTable> builder)
        {
            builder.ToTable(ProjectManagerConstants.SysJobTable_TABLENAME);
            builder.Property(x => x.Code).HasColumnName("Code").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Barcode).HasColumnName("Barcode").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.SysJobId).HasColumnName("SysJobId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.No).HasColumnName("No").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.SheetName).HasColumnName("SheetName").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.SheetIndex).HasColumnName("SheetIndex").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.TableIndex).HasColumnName("TableIndex").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Title).HasColumnName("Title").HasMaxLength(1024).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.TitleFontSize).HasColumnName("TitleFontSize").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.IsShowTitle).HasColumnName("IsShowTitle").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.IsShowTotal).HasColumnName("IsShowTotal").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.IsHeader).HasColumnName("IsHeader").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.IsFreezeHeader).HasColumnName("IsFreezeHeader").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.HeaderColor).HasColumnName("HeaderColor").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.HeaderBackGroundColor).HasColumnName("HeaderBackGroundColor").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.HeaderBackGroundStyleId).HasColumnName("HeaderBackGroundStyleId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.HeaderFontSize).HasColumnName("HeaderFontSize").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.IsAutoFit).HasColumnName("IsAutoFit").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Border).HasColumnName("Border").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.BorderStyleId).HasColumnName("BorderStyleId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.BackGroundColor).HasColumnName("BackGroundColor").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.BeginRow).HasColumnName("BeginRow").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.BeginCol).HasColumnName("BeginCol").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Style).HasColumnName("Style").HasMaxLength(2048).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.FontStyleId).HasColumnName("FontStyleId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.FontSize).HasColumnName("FontSize").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Color).HasColumnName("Color").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Priority).HasColumnName("Priority").UsePropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
