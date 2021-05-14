using Acc.Cmd.Domain.DomainObjects;
using Acc.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Acc.Cmd.Infrastructure.EFConfig
{
    public class RelationTableConfiguration : IEntityTypeConfiguration<RelationTable>
    {
        public void Configure(EntityTypeBuilder<RelationTable> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.RelationTable_TABLENAME);
            builder.Property(x => x.PrimaryTable).HasField("_primaryTable").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.PrimaryKey).HasField("_primaryKey").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ForeignTable).HasField("_foreignTable").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ForeignKey).HasField("_foreignKey").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
