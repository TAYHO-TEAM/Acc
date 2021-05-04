using AppWFGenProject.Entities;
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
        public Paging<SysJob> GetAllSysJob(int currentPage =1)
        {
            var totalRecord = _dbContext.SysJob
                                .Where(x=>(x.IsDelete == null || x.IsDelete == false) && x.IsActive == true)
                                .Select(x=>x.Id)
                                .Count();
            Paging<SysJob> paging = new Paging<SysJob>(currentPage,20,totalRecord);
            paging.Items = _dbContext.SysJob
                                .Where(x => (x.IsDelete == null || x.IsDelete == false) && x.IsActive == true)
                                .Skip(paging.Skip())
                                .Take(paging.Take())
                                .ToList();
            return paging;
        }    
    }
}
