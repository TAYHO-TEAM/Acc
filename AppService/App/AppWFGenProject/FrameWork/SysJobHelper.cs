
using AppWFGenProject.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
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

        protected readonly ProjectManagerBaseContext _dbContext;
        protected readonly IServiceScopeFactory _serviceScopeFactory;
        public SysJobHelper(IServiceScopeFactory serviceScopeFactory)//ProjectManagerBaseContext projectManagerBaseContext, 
        {
            _serviceScopeFactory = serviceScopeFactory;
            using var scope = _serviceScopeFactory.CreateScope();
            _dbContext = scope.ServiceProvider.GetRequiredService<ProjectManagerBaseContext>();
            //_dbContext = projectManagerBaseContext;
            _dbContext.ChangeTracker.DetectChanges();
        }
        public async Task<Paging<SysJob>> GetAllSysJob(int currentPage = 1 )
        {
            //using var scope = _serviceScopeFactory.CreateScope();
            ProjectManagerBaseContext _db = new ProjectManagerBaseContext();
            try
            {
                var totalRecord = _db.SysJob
                                    .Where(x => (x.IsDelete == null || x.IsDelete == false) && x.IsActive == true)
                                    .Select(x => x.Id)
                                    .Count();
                Paging<SysJob> paging = new Paging<SysJob>(currentPage, 20, 0);
                paging.Items = _db.SysJob
                                    .Where(x => (x.IsDelete == null || x.IsDelete == false) && x.IsActive == true)
                                    .Skip(paging.Skip())
                                    .Take(paging.Take())
                                    .ToList();
                return paging;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
