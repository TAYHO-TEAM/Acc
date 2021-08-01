using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OperationManager.CRUD.Common;
using OperationManager.CRUD.DAL.DTO.OperationManagerDTO;

namespace OperationManager.CRUD.DAL.EFConfig.OperationManagerEFConfig
{
    public class ProjectConfiguration
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable(OperationManagerConstants.Project_TABLENAME);
            builder.Property(x => x.Code).HasColumnName("Code").HasMaxLength(64).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.BarCode).HasColumnName("BarCode").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Title).HasColumnName("Title").HasMaxLength(1024).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Descriptions).HasColumnName("Descriptions").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ParentId).HasColumnName("ParentId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.NodeLevel).HasColumnName("NodeLevel").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.OldId).HasColumnName("OldId").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
