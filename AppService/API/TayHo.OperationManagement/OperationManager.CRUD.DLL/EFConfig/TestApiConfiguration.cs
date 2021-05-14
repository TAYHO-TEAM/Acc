using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Operationmanager.Common;
using OperationManager.CRUD.DAL.DTO;
namespace OperationManager.CRUD.DAL.EFConfig
{
    public class TestApiConfiguration
    {
        public void Configure(EntityTypeBuilder<TestApi> builder)
        {
            builder.ToTable(OperationManagerConstants.TestApi_TABLENAME);
        }
    }
}
