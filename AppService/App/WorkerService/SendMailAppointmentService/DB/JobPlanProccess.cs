using Microsoft.EntityFrameworkCore;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using ProjectManager.CMD.Infrastructure;
using SendMailAppointmentService.DTO;
using Services.Common.APIs.Cmd.EF;
using Services.Common.APIs.Cmd.EF.Extensions;
using Services.Common.APIs.Cmd.EF.IRepository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SendMailAppointmentService.DB
{
    public class JobPlanProccess
    {
        protected readonly DbSet<T> _dbSet;
        private readonly ProjectManagerBaseContext _dbContext ;
        public JobPlanProccess(ProjectManagerBaseContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public List<string> GetToMail()
        {
            List<string> toMail = new List<string>();
            return toMail;
        }
        public List<string> GetCCMail()
        {
            List<string> ccMail = new List<string>();
            return ccMail;
        }
        public List<string> GetBCCMail()
        {
            List<string> bccMail = new List<string>();
            return bccMail;
        }
        public async Task<IList<ResultListId>> GetPlanMasterReport()
        {
            List<int> idPlanMaster = new List<int>();
            SprocRepository _sprocRepository = new SprocRepository(_dbContext);
            //var result = await _sprocRepository.GetStoredProcedure("sp_PlanReport_Process_GetPlanMasterId")
            //                             .WithSqlParams()
            //                             .ExecuteStoredProcedureAsync<ResultListId>();
            var result = await _sprocRepository.GetStoredProcedure("sp_PlanReport_Process_GetPlanMasterId")
                                       .ExecuteStoredProcedureAsync<ResultListId>();
            return result;

        }


    }

}
