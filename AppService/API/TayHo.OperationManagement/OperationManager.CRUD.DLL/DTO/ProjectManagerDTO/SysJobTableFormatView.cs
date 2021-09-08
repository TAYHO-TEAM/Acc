using OperationManager.CRUD.DAL.DTO.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OperationManager.CRUD.DAL.DTO.ProjectManagerDTO
{
    public class SysJobTableFormatView : DOBase
    {
        public string Code { get; set; }
        public string Barcode { get; set; }
        public int? SysJobId { get; set; }
        public int? No { get; set; }
        public string SheetName { get; set; }
        public int? SheetIndex { get; set; }
        public int? TableIndex { get; set; }
        public string Title { get; set; }
        public int? Priority { get; set; }
        public int? Border { get; set; }
        public int? BorderStyleId { get; set; }
        public int? FontStyleId { get; set; }
        public string FontStyle { get; set; }
        public int? FontSize { get; set; }
        public string Color { get; set; }
        public bool? IsGenIamge { get; set; }
        public double? HeightImage { get; set; }
        public double? WidthImage { get; set; }
        public string ColsImage { get; set; }
        public bool? IsAutoCropImage { get; set; }
        public bool? IsAutoFit { get; set; }
        public bool? IsFreezeHeader { get; set; }
        public int? HeaderFontSize { get; set; }
        public int? HeaderBackGroundStyleId { get; set; }
        public string HeaderBackGroundStyle { get; set; }
        public int? HeaderBackGroundColorId { get; set; }
        public int? HeaderColorId { get; set; }
        public bool? IsShowTotal { get; set; }
        public string ColsTotal { get; set; }
        public bool? IsShowTitle { get; set; }
        public int? TitleFontSize { get; set; }
        public int? TitleFontId { get; set; }
        public string TitleFont { get; set; }
        public bool? IsMergeCol { get; set; }
        public int? ColFirstMerge { get; set; }
        public int? ColEndMerge { get; set; }
        public bool? IsMergeRow { get; set; }
        public string ColsMerge { get; set; }
        public bool? IsHeader { get; set; }
        public int? BeginRow { get; set; }
        public int? BeginCol { get; set; }
        public int? VerticalAlignment { get; set; }
        public int? HorizontalAlignment { get; set; }
        public int? FontId { get; set; }
        public string Font { get; set; }
        public int? HeaderFontId { get; set; }
        public int? HeaderFontStyleId { get; set; }
        public string HeaderFont { get; set; }
        public string HeaderFontStyle { get; set; }

    }
}
