using ProjectManager.CMD.Domain.DomainObjects;
using Services.Common.DomainObjects.Interfaces;
using System.Threading.Tasks;

namespace ProjectManager.CMD.Domain.IRepositories
{
    public interface IPlanMasterRepository :  ICmdRepository<PlanMaster>
    {
        Task<string> GenCodeAsync(int id, string tableName);
    }
}
    
