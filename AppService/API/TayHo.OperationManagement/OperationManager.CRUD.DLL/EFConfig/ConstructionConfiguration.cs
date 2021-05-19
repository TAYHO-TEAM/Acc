using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OperationManager.CRUD.Common;
using OperationManager.CRUD.DAL.DTO;

namespace OperationManager.CRUD.DAL.EFConfig
{
    public class ConstructionConfiguration
    {
        public void Configure(EntityTypeBuilder<Construction> builder)
        {
           builder.Property(x => x.ConstructionCategoryId).HasColumnName("ConstructionCategoryId").UsePropertyAccessMode(PropertyAccessMode.Field);
	builder.Property(x => x.ProjectId).HasColumnName("ProjectId").UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.Code).HasColumnName("Code").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.BarCode).HasColumnName("BarCode").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.ParentId).HasColumnName("ParentId").UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.Title).HasColumnName("Title").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.Descriptions).HasColumnName("Descriptions").HasMaxLength(1024).UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.Priority).HasColumnName("Priority").UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.Type).HasColumnName("Type").UsePropertyAccessMode(PropertyAccessMode.Field);
			
        }
    }
}
