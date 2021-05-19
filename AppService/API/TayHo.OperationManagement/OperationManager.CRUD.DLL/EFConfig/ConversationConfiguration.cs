using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OperationManager.CRUD.Common;
using OperationManager.CRUD.DAL.DTO;

namespace OperationManager.CRUD.DAL.EFConfig
{
    public class ConversationConfiguration
    {
        public void Configure(EntityTypeBuilder<Conversation> builder)
        {
            builder.ToTable(OperationManagerConstants.Conversation_TABLENAME);
            builder.Property(x => x.OwnerTable).HasColumnName("OwnerTable").HasMaxLength(128).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.TopicId).HasColumnName("TopicId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ParentId).HasColumnName("ParentId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Content).HasColumnName("Content").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.NoAttachment).HasColumnName("NoAttachment").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
