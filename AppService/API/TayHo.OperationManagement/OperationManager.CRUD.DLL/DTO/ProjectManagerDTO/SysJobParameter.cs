using OperationManager.CRUD.DAL.DTO.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OperationManager.CRUD.DAL.DTO.ProjectManagerDTO
{
    public class SysJobParameter : DOBase
    {
        public string Code { get; set; }
        public string Barcode { get; set; }
        public int SysJobId { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string DataTypeSQL { get; set; }
        public string DataTypeC { get; set; }
        public string DefaultValue { get; set; }

    }
}
