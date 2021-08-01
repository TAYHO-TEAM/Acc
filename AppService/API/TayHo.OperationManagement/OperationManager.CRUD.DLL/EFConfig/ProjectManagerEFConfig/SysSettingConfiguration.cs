using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OperationManager.CRUD.Common;
using OperationManager.CRUD.DAL.DTO.ProjectManagerDTO;

namespace OperationManager.CRUD.DAL.EFConfig
{
    public class SysSettingConfiguration
    {
        public void Configure(EntityTypeBuilder<SysSetting> builder)
        {
            builder.ToTable(ProjectManagerConstants.SysSetting_TABLENAME);
            builder.Property(x => x.ParentId).HasColumnName("ParentId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Code).HasColumnName("Code").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Barcode).HasColumnName("Barcode").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Category).HasColumnName("Category").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Name).HasColumnName("Name").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Type).HasColumnName("Type").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.TypeId).HasColumnName("TypeId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.SettingContent).HasColumnName("SettingContent").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Priority).HasColumnName("Priority").UsePropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
