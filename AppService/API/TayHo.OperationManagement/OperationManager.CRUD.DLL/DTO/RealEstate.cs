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
        public string Street { get; set; }
        public string District { get; set; }
        public string Ward { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public int? Type { get; set; }

    }
}
