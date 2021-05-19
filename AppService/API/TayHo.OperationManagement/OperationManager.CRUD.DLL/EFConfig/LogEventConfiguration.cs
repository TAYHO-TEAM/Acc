using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OperationManager.CRUD.Common;
using OperationManager.CRUD.DAL.DTO;

namespace OperationManager.CRUD.DAL.EFConfig
{
    public class LogEventConfiguration
    {
        public void Configure(EntityTypeBuilder<LogEvent> builder)
        {
           builder.Property(x => x.UserId).HasColumnName("UserId").UsePropertyAccessMode(PropertyAccessMode.Field);
	builder.Property(x => x.Event).HasColumnName("Event").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.Action).HasColumnName("Action").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.OwnerById).HasColumnName("OwnerById").UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.OwnerByTable).HasColumnName("OwnerByTable").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.FunctionId).HasColumnName("FunctionId").UsePropertyAccessMode(PropertyAccessMode.Field);
			builder.Property(x => x.Message).HasColumnName("Message").UsePropertyAccessMode(PropertyAccessMode.Field);
			
        }
    }
}
