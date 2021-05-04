using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWFGenProject.FrameWork
{
    public class SysJobHelper
    {
        //protected readonly ISysJobTableRepository _sysJobTableRepository;
        protected readonly ProjectManagerBaseContext _dbContext;
        public void GetAllSysJob()
        {
            var totalRecord = _dbContext.SysJob
                                .Where(x=>(x.IsDelete == null || x.IsDelete == false) && x.IsActive == true)
                                .Select(x=>x.Id)
                                .Count();
            List<SysJob> sysJobs = _dbContext.SysJob
                                .Where(x => (x.IsDelete == null || x.IsDelete == false) && x.IsActive == true)
                                .Skip(1)
                                .Take(50)
                                .ToList();
            //var list = await _sysJobTableRepository.GetAllListAsync(x=>x.Equals("*")).ConfigureAwait(false);

        }    
    }
}
