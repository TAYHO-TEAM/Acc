using OperationManager.CRUD.DAL.DTO.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OperationManager.CRUD.DAL.DTO.OperationManagerDTO
{
    public class Construction : DOBase
    {
        public int? ConstructionCategoryId { get; set; }
        public int? ProjectId { get; set; }
        public string Code { get; set; }
        public string BarCode { get; set; }
        public int? ParentId { get; set; }
        public string Title { get; set; }
        public string Descriptions { get; set; }
        public int? Priority { get; set; }
        public int? Type { get; set; }

    }
}
