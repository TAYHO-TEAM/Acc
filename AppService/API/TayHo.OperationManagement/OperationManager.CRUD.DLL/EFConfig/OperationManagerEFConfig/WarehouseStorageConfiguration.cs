using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OperationManager.CRUD.Common;
using OperationManager.CRUD.DAL.DTO.OperationManagerDTO;

namespace OperationManager.CRUD.DAL.EFConfig.OperationManagerEFConfig
{
    public class WarehouseStorageConfiguration
    {
        public void Configure(EntityTypeBuilder<WarehouseStorage> builder)
        {
            builder.ToTable(OperationManagerConstants.WarehouseStorage_TABLENAME);
           builder.Property(x => x.RealEstateId).HasColumnName("RealEstateId").UsePropertyAccessMode(PropertyAccessMode.Field);
	builder.Property(x => x.ParentId).HasColumnName("ParentId").UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.Code).HasColumnName("Code").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.Barcode).HasColumnName("Barcode").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.CategoryStorageId).HasColumnName("CategoryStorageId").UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.Title).HasColumnName("Title").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.PositionX).HasColumnName("PositionX").UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.PositionY).HasColumnName("PositionY").UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.PositionZ).HasColumnName("PositionZ").UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.Hight).HasColumnName("Hight").UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.Width).HasColumnName("Width").UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.Depth).HasColumnName("Depth").UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.Unit).HasColumnName("Unit").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.UnitType).HasColumnName("UnitType").UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.Weight).HasColumnName("Weight").UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.WeightUp).HasColumnName("WeightUp").UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.UnitWeight).HasColumnName("UnitWeight").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.UnitWeightType).HasColumnName("UnitWeightType").UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.Priority).HasColumnName("Priority").UsePropertyAccessMode(PropertyAccessMode.Field);
			
        }
    }
}
