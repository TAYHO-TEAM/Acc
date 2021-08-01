using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OperationManager.CRUD.Common;
using OperationManager.CRUD.DAL.DTO.OperationManagerDTO;

namespace OperationManager.CRUD.DAL.EFConfig.OperationManagerEFConfig
{
    public class CategoryGoodsConfiguration
    {
        public void Configure(EntityTypeBuilder<CategoryGoods> builder)
        {
            builder.ToTable(OperationManagerConstants.CategoryGoods_TABLENAME);
            builder.Property(x => x.ParentId).HasColumnName("ParentId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Code).HasColumnName("Code").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Barcode).HasColumnName("Barcode").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Title).HasColumnName("Title").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Hight).HasColumnName("Hight").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Width).HasColumnName("Width").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Depth).HasColumnName("Depth").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.UnitId).HasColumnName("UnitId").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.UnitMeasureId).HasColumnName("UnitMeasureId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Weight).HasColumnName("Weight").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.WeightUp).HasColumnName("WeightUp").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.UnitWeightId).HasColumnName("UnitWeightId").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Description).HasColumnName("Description").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Type).HasColumnName("Type").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Priority).HasColumnName("Priority").UsePropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
