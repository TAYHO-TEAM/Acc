using AutoMapper;
using DevExtreme.AspNet.Data.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using OperationManager.CRUD.BLL.IRepositories;
using OperationManager.CRUD.DAL.DBContext;
using OperationManager.CRUD.DAL.DTO.ProjectManagerDTO;
using Services.Common.APIs.Cmd.EF;
using Services.Common.APIs.Cmd.EF.Extensions;
using Services.Common.Media;
using Services.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationManager.CRUD.BLL.Repositories
{
    public class ReportRepository : IReportRepository
    {
        protected readonly QuanLyVanHanhContext _dbContext;
        public ReportRepository(QuanLyVanHanhContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Tuple<MemoryStream, string, string>> ReportSheetGet(int RecordId, params (string, object)[] parameter)
        {
            var memoryStream = new MemoryStream();

            List<DataTable> tables = new List<DataTable>();
            SprocRepository _sprocRepository = new SprocRepository(_dbContext);
            (string, object)[] paramSysJob = new (string, object)[] { ("@RecordId", RecordId) };
            IList<SysJob> resultSysJobs = await _sprocRepository.GetStoredProcedure("sp_Report_GetSysJob")
                                                                .WithSqlParams(paramSysJob)
                                                                .ExecuteStoredProcedureAsync<SysJob>();

            if (resultSysJobs.Count > 0)
            {
                SysJob sysJob = resultSysJobs[0];

                //// get tempalte 
                string _dirTemplate = "";
                (string, object)[] paramSysTemplateReport = new (string, object)[] { ("@RecordId", sysJob.SysTemplateReportId ?? 0) };
                IList<SysTemplateReport> resultSysTemplates = await _sprocRepository.GetStoredProcedure("sp_Report_GetSysTemplate")
                                                              .WithSqlParams(paramSysTemplateReport)
                                                              .ExecuteStoredProcedureAsync<SysTemplateReport>();
                _dirTemplate = (resultSysTemplates.Count > 0 && !string.IsNullOrEmpty(resultSysTemplates[0].Direct)) ? resultSysTemplates[0].Direct : "";

                (string, object)[] paramSysJobTable = new (string, object)[] { ("@RecordId", sysJob.Id) };
                IList<SysJobTable> resultSysJobTables = await _sprocRepository.GetStoredProcedure("sp_Report_GetSysJobTable")
                                                              .WithSqlParams(paramSysJobTable)
                                                              .ExecuteStoredProcedureAsync<SysJobTable>();
                SysJobTable sysJobTable = resultSysJobTables.Count > 0 ? resultSysJobTables[0] : null;
                

                var _template = Path.GetFileNameWithoutExtension(_dirTemplate);
                string ext = Path.GetExtension(_dirTemplate).ToLowerInvariant();
                ext = string.IsNullOrEmpty(ext) ? ".xlsx" : ext;

                DataTable result = await _sprocRepository.GetStoredProcedure(sysJob.NameStoreProce)
                       .WithSqlParams(parameter)
                       .ExecuteStoredProcedureToTableAsync();

                if (result != null)
                {
                    GenImage genImage = new GenImage();
                    genImage.Height = 200;
                    genImage.Width = 0;
                    genImage.IsAutoCrop = true;
                    genImage.IsGenIamge = true;
                    genImage.ColImage = "Image,image,";
                    memoryStream = EpplusHelper.Export(result, sysJobTable != null ? sysJobTable.SheetName : "", genImage, sysJobTable.IsShowTitle ?? false, _dirTemplate, sysJobTable.BeginCol ?? 1, sysJobTable.BeginRow ?? 1, sysJobTable.IsHeader ?? false, false);
                    memoryStream.Position = 0;
                    Tuple<MemoryStream, string, string> _result = new Tuple<MemoryStream, string, string>(memoryStream, FileHelpers.GetMimeTypes()[ext], Path.GetFileNameWithoutExtension(_template) + DateTime.Now.ToString("yyyyMMdd") + ext);
                    return _result;
                }
                else
                {
                    return new Tuple<MemoryStream, string, string>(null, null, null);
                }
            }
            else
            {
                return new Tuple<MemoryStream, string, string>(null, null, null);
            }
        }
        public async Task<Tuple<MemoryStream, string, string>> ReportSheetsGet(int RecordId, params (string, object)[] parameter)
        {
            var memoryStream = new MemoryStream();

            List<DataTable> tables = new List<DataTable>();
            SprocRepository _sprocRepository = new SprocRepository(_dbContext);
            (string, object)[] paramSysJob = new (string, object)[] { ("@RecordId", RecordId) };
            IList<SysJob> resultSysJobs = await _sprocRepository.GetStoredProcedure("sp_Report_GetSysJob")
                                                                .WithSqlParams(paramSysJob)
                                                                .ExecuteStoredProcedureAsync<SysJob>();

            if (resultSysJobs.Count > 0)
            {
                SysJob sysJob = resultSysJobs[0];

                //// get tempalte 
                string _dirTemplate = "";
                (string, object)[] paramSysTemplateReport = new (string, object)[] { ("@RecordId", sysJob.SysTemplateReportId ?? 0) };
                IList<SysTemplateReport> resultSysTemplates = await _sprocRepository.GetStoredProcedure("sp_Report_GetSysTemplate")
                                                              .WithSqlParams(paramSysTemplateReport)
                                                              .ExecuteStoredProcedureAsync<SysTemplateReport>();
                _dirTemplate = (resultSysTemplates.Count > 0 && !string.IsNullOrEmpty(resultSysTemplates[0].Direct)) ? resultSysTemplates[0].Direct : "";

                (string, object)[] paramSysJobTable = new (string, object)[] { ("@RecordId", sysJob.Id) };
                IList<SysJobTable> resultSysJobTables = await _sprocRepository.GetStoredProcedure("sp_Report_GetSysJobTable")
                                                              .WithSqlParams(paramSysJobTable)
                                                              .ExecuteStoredProcedureAsync<SysJobTable>();
                SysJobTable sysJobTable = resultSysJobTables.Count > 0 ? resultSysJobTables[0] : null;

                var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<SysJobTable, TableProperty>()
                );
                var mapper = new Mapper(config);
                var tableProperties = mapper.Map<IList<SysJobTable>, IList<TableProperty>>(resultSysJobTables.ToList());


                var _template = Path.GetFileNameWithoutExtension(_dirTemplate);
                string ext = Path.GetExtension(_dirTemplate).ToLowerInvariant();
                ext = string.IsNullOrEmpty(ext) ? ".xlsx" : ext;

               
                DataTable result = await _sprocRepository.GetStoredProcedure(sysJob.NameStoreProce)
                     .WithSqlParams(parameter)
                     .ExecuteStoredProcedureToTableAsync();
                List<DataTable> results = await _sprocRepository.GetStoredProcedure(sysJob.NameStoreProce)
                      .WithSqlParams(parameter)
                      .ExecuteStoredProcedureAsync();
                foreach ( var tableprop in  tableProperties)
                {
                    if (results.ElementAtOrDefault((tableprop.TableIndex??1) -1 ) != null)
                    {
                        tableprop.DataSource = results[(tableprop.TableIndex ?? 1) - 1];
                        tableprop.GenImage = new GenImage();
                    }
                }    
               
                if (tableProperties.Count >0 )
                {
                    //GenImage genImage = new GenImage();
                    //genImage.Height = 200;
                    //genImage.Width = 0;
                    //genImage.IsAutoCrop = true;
                    //genImage.IsGenIamge = true;
                    //genImage.ColImage = "Image,image,";
                    memoryStream = EpplusHelper.Export(tableProperties, _template);
                    memoryStream.Position = 0;
                    Tuple<MemoryStream, string, string> _result = new Tuple<MemoryStream, string, string>(memoryStream, FileHelpers.GetMimeTypes()[ext], Path.GetFileNameWithoutExtension(_template) + DateTime.Now.ToString("yyyyMMdd") + ext);
                    return _result;
                }
                else
                {
                    return new Tuple<MemoryStream, string, string>(null, null, null);
                }
            }
            else
            {
                return new Tuple<MemoryStream, string, string>(null, null, null);
            }
        }
    }
}
