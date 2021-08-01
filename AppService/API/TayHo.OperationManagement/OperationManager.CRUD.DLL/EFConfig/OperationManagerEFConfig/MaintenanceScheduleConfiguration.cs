using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OperationManager.CRUD.Common;
using OperationManager.CRUD.DAL.DTO.OperationManagerDTO;

namespace OperationManager.CRUD.DAL.EFConfig.OperationManagerEFConfig
{
    public class MaintenanceScheduleConfiguration
    {
        public void Configure(EntityTypeBuilder<MaintenanceSchedule> builder)
        {
            builder.ToTable(OperationManagerConstants.MaintenanceSchedule_TABLENAME);
            builder.Property(x => x.Code).HasColumnName("Code").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Barcode).HasColumnName("Barcode").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ConstructionItemsId).HasColumnName("ConstructionItemsId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.MaintenanceSupplierInfoId).HasColumnName("MaintenanceSupplierInfoId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.MaintenancerInfoId).HasColumnName("MaintenancerInfoId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Title).HasColumnName("Title").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Cycle).HasColumnName("Cycle").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Priority).HasColumnName("Priority").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.IsRemind).HasColumnName("IsRemind").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.RemindBy).HasColumnName("RemindBy").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.LastTimes).HasColumnName("LastTimes").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.NextTimes).HasColumnName("NextTimes").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.StartDate).HasColumnName("StartDate").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.EndDate).HasColumnName("EndDate").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Times).HasColumnName("Times").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.StartTime).HasColumnName("StartTime").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.EndTime).HasColumnName("EndTime").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Type).HasColumnName("Type").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.NoAttachment).HasColumnName("NoAttachment").UsePropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
