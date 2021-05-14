using Acc.Read.Sql.DTOs.BaseClasses;
using System;

namespace Acc.Read.Sql.DTOs
{
    public class WorkItemsDTO : SysDTOBase
    {
        public string Code { get; set; }
        public string BarCode { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? ParentId { get; set; }
        public int? level { get; set; }
        public int? ProjectId { get; set; }
    }
}
