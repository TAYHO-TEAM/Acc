using OperationManager.CRUD.DAL.DTO.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OperationManager.CRUD.DAL.DTO.ProjectManagerDTO
{
    public class SysJobTable : DOBase
    {
        public string Code { get; set; }
        public string Barcode { get; set; }
        public int? SysJobId { get; set; }
        public int? No { get; set; }
        public string SheetName { get; set; }
        public int? SheetIndex { get; set; }
        public int? TableIndex { get; set; }
        public string Title { get; set; }
        public int? TitleFontSize { get; set; }
        public bool? IsShowTitle { get; set; }
        public bool? IsShowTotal { get; set; }
        public bool? IsHeader { get; set; }
        public bool? IsFreezeHeader { get; set; }
        public string HeaderColor { get; set; }
        public string HeaderBackGroundColor { get; set; }
        public int? HeaderBackGroundStyleId { get; set; }
        public int? HeaderFontSize { get; set; }
        public bool? IsAutoFit { get; set; }
        public int? Border { get; set; }
        public int? BorderStyleId { get; set; }
        public string BackGroundColor { get; set; }
        public int? BeginRow { get; set; }
        public int? BeginCol { get; set; }
        public string Style { get; set; }
        public int? FontStyleId { get; set; }
        public int? FontSize { get; set; }
        public string Color { get; set; }
        public int? Priority { get; set; }

    }
}
