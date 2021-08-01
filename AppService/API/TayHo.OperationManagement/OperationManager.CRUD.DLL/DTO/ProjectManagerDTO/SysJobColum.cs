using OperationManager.CRUD.DAL.DTO.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OperationManager.CRUD.DAL.DTO.ProjectManagerDTO
{
    public class SysJobColum : DOBase
    {
        public string Code { get; set; }
        public string Barcode { get; set; }
        public int? NoCol { get; set; }
        public int? SysJobTableId { get; set; }
        public string Style { get; set; }
        public string Formulas { get; set; }
        public string Functions { get; set; }
        public int? Border { get; set; }
        public string Color { get; set; }
        public string BackGroundColor { get; set; }

    }
}
