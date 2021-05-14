using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Operationmanager.CRUD.Common;
using OperationManager.CRUD.DAL.DTO;
namespace OperationManager.CRUD.DAL.EFConfig
{
    public class TestApiConfiguration
    {
        public void Configure(EntityTypeBuilder<TestApi> builder)
        {
            builder.ToTable(OperationManagerConstants.TestApi_TABLENAME);
            builder.Property(x => x.Name).HasColumnName("Name").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
