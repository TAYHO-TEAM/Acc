using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OperationManager.CRUD.Common;
using OperationManager.CRUD.DAL.DTO.OperationManagerDTO;

namespace OperationManager.CRUD.DAL.EFConfig.OperationManagerEFConfig
{
    public class MaintenanceLogConfiguration
    {
        public void Configure(EntityTypeBuilder<MaintenanceLog> builder)
        {
            builder.ToTable(OperationManagerConstants.MaintenanceLog_TABLENAME);
            builder.Property(x => x.Code).HasColumnName("Code").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Barcode).HasColumnName("Barcode").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Priority).HasColumnName("Priority").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ConstructionItemsId).HasColumnName("ConstructionItemsId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.MaintenancerInfoId).HasColumnName("MaintenancerInfoId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.MaintenanceSupplierInfoId).HasColumnName("MaintenanceSupplierInfoId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.MaintenanceScheduleId).HasColumnName("MaintenanceScheduleId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.MaintaincerName).HasColumnName("MaintaincerName").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.MaintaincerPhone).HasColumnName("MaintaincerPhone").HasMaxLength(64).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Note).HasColumnName("Note").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Result).HasColumnName("Result").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ResultType).HasColumnName("ResultType").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.CurrentTimes).HasColumnName("CurrentTimes").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Times).HasColumnName("Times").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.StartTime).HasColumnName("StartTime").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.EndTime).HasColumnName("EndTime").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Duration).HasColumnName("Duration").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.DurationUnit).HasColumnName("DurationUnit").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.DurationUnitType).HasColumnName("DurationUnitType").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Type).HasColumnName("Type").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.NoAttachment).HasColumnName("NoAttachment").UsePropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
