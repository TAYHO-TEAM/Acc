using ProjectManager.CMD.Domain.DomainObjects;
using Services.Common.DomainObjects.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectManager.CMD.Domain.IRepositories
{
    public interface IAccountInfoRepository : ICmdRepository<AccountInfo>
    {
        Task<List<string>> IsGetToMailsAsync(int AccountId = 0);
    }
}
