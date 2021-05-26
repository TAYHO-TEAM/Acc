using OperationManager.CRUD.DAL.DTO.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OperationManager.CRUD.DAL.DTO
{
    public class RealEstate : DOBase
    {
        public int? ConstructionItemsId { get; set; }
        public string BarCode { get; set; }
        public string Code { get; set; }
        public string Address { get; set; }
        public int? Type { get; set; }

    }
}
