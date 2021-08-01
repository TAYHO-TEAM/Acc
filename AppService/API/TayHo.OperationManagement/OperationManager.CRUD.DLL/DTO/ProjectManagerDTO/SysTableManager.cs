using OperationManager.CRUD.DAL.DTO.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OperationManager.CRUD.DAL.DTO.ProjectManagerDTO
{
    public class SysTableManager : DOBase
    {
        public string Code { get; set; }
        public string Barcode { get; set; }
        public string TableName { get; set; }
        public string HeaderCode { get; set; }
        public bool? IsGenCode { get; set; }
        public bool? IsPushNotify { get; set; }
        public string TypeNotify { get; set; }
        public string QuerryString { get; set; }
        public string StoreProcName { get; set; }

    }
}
