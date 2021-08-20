using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OperationManager.CRUD.Common;
using OperationManager.CRUD.DAL.DTO.OperationManagerDTO;

namespace OperationManager.CRUD.DAL.EFConfig.OperationManagerEFConfig
{
    public class SysJobWithAccountConfiguration
    {
        public void Configure(EntityTypeBuilder<SysJobWithAccount> builder)
        {
            builder.ToTable(OperationManagerConstants.SysJobWithAccount_TABLENAME);
            builder.Property(x => x.Code).HasField("_code").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Barcode).HasField("_barcode").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.SysTemplateReportId).HasField("_sysTemplateReportId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.JobName).HasField("_jobName").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.NameDataBase).HasField("_nameDataBase").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.NameStoreProce).HasField("_nameStoreProce").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ConnStringHash).HasField("_connStringHash").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Salt).HasField("_salt").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.StartTime).HasField("_startTime").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.EndTime).HasField("_endTime").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.StartDate).HasField("_startDate").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.EndDate).HasField("_endDate").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.FirstDate).HasField("_firstDate").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.LastDate).HasField("_lastDate").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.NextDate).HasField("_nextDate").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Times).HasField("_times").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Unit).HasField("_unit").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.StepTime).HasField("_stepTime").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Priority).HasField("_priority").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.IsTemplate).HasField("_isTemplate").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.AccountId).HasField("_accountId").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
