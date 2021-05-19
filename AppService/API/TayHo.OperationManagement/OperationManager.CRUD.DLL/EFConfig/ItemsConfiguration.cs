using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OperationManager.CRUD.Common;
using OperationManager.CRUD.DAL.DTO;

namespace OperationManager.CRUD.DAL.EFConfig
{
    public class ItemsConfiguration
    {
        public void Configure(EntityTypeBuilder<Items> builder)
        {
           builder.Property(x => x.ContructionCategoryId).HasColumnName("ContructionCategoryId").UsePropertyAccessMode(PropertyAccessMode.Field);
	builder.Property(x => x.Code).HasColumnName("Code").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.Barcode).HasColumnName("Barcode").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.Title).HasColumnName("Title").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.Descriptions).HasColumnName("Descriptions").HasMaxLength(1024).UsePropertyAccessMode(PropertyAccessMode.Field);
			
        }
    }
}
