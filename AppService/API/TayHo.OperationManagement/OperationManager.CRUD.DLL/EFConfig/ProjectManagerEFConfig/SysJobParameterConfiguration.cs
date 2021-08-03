using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OperationManager.CRUD.Common;
using OperationManager.CRUD.DAL.DTO.ProjectManagerDTO;

namespace OperationManager.CRUD.DAL.EFConfig
{
    public class SysJobParameterConfiguration
    {
        public void Configure(EntityTypeBuilder<SysJobParameter> builder)
        {
            builder.ToTable(ProjectManagerConstants.SysJobParameter_TABLENAME);
            builder.Property(x => x.Code).HasColumnName("Code").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Barcode).HasColumnName("Barcode").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.SysJobId).HasColumnName("SysJobId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Name).HasColumnName("Name").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.DisplayName).HasColumnName("DisplayName").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.DataTypeSQL).HasColumnName("DataTypeSQL").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.DataTypeC).HasColumnName("DataTypeC").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.DefaultValue).HasColumnName("DefaultValue").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
