using OperationManager.CRUD.DAL.DTO.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OperationManager.CRUD.DAL.DTO.OperationManagerDTO
{
    public class ConstructionItems : DOBase
    {
        public int? ParentId { get; set; }
        public int? ProjectId { get; set; }
        public string Code { get; set; }
        public string Barcode { get; set; }
        public string Icon { get; set; }
        public string Thumbnail { get; set; }
        public string Title { get; set; }
        public string Descriptions { get; set; }
        public int? NoAttachment { get; set; }
        public int? Priority { get; set; }

    }
}
