using DevExtreme.AspNet.Data.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using Services.Common.DevExpress;
using System;
using System.IO;
using System.Threading.Tasks;

namespace OperationManager.CRUD.BLL.IRepositories
{
    public interface IReportRepository
    {
        Task<Tuple<MemoryStream, string, string>> ReportSheetGet(int RecordId, params (string, object)[] parameter);
    }
}
