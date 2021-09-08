using OperationManager.CRUD.DAL.DTO.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OperationManager.CRUD.DAL.DTO.ProjectManagerDTO
{
    public class SysJobColumView : DOBase
    {
        public string Code { get; set; }
        public string Barcode { get; set; }
        public int? SysJobTableId { get; set; }
        public bool? IsAutoFit { get; set; }
        public int? NoCol { get; set; }
        public string Style { get; set; }
        public string Formulas { get; set; }
        public string Functions { get; set; }
        public int? Border { get; set; }
        public string Color { get; set; }
        public int? FontStyleId { get; set; }
        public int? FontId { get; set; }
        public int? FontSize { get; set; }
        public int? BackGroundStyleId { get; set; }
        public int? BackGroundColorId { get; set; }
        public int? VerticalAlignment { get; set; }
        public int? HorizontalAlignment { get; set; }
        public bool? IsWrapText { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public string FontStyle { get; set; }
        public string BackGroundStyle { get; set; }
        public string Font { get; set; }
    }
}
