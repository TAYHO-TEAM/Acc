using OperationManager.CRUD.DAL.DTO.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OperationManager.CRUD.DAL.DTO.ProjectManagerDTO
{
    public class SysTemplateReport : DOBase
    {
        public string Barcode { get; set; }
        public string Code { get; set; }
        public string FileName { get; set; }
        public string DisplayName { get; set; }
        public string Tail { get; set; }
        public string Url { get; set; }
        public string Host { get; set; }
        public string Type { get; set; }
        public string Direct { get; set; }

    }
}
