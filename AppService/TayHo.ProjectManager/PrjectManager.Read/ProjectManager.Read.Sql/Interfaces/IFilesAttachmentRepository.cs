using ProjectManager.Read.Sql.DTOs.DTO;
using ProjectManager.Read.Sql.Parameters;
using Services.Common.Paging;
using System.Threading.Tasks;

namespace ProjectManager.Read.Sql.Interfaces
{
    public interface IFilesAttachmentRepository<T> where T : class
    {
        Task<PagingItems<T>> GetFilesAttachmentByAsync(RequestHasAccountIdFilterParam requetsBaseFilterParam);
        Task LogGetFileByAsync(int AccountId, string DocumentReleasedId, string TableName);
    }
}

