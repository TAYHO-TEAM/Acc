using OperationManager.CRUD.DAL.DTO.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OperationManager.CRUD.DAL.DTO
{
    public class Items : DOBase
    {
        public int? ContructionCategoryId { get; set; }
        public string Code { get; set; }
        public string Barcode { get; set; }
        public string Title { get; set; }
        public string Descriptions { get; set; }

    }
}
