using OperationManager.CRUD.DAL.DTO.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OperationManager.CRUD.DAL.DTO
{
    public class MaintenanceSupplierInfo : DOBase
    {
        public string Code { get; set; }
        public string Barcode { get; set; }
        public int? ParentId { get; set; }
        public string TaxCode { get; set; }
        public string Name { get; set; }
        public string Descriptions { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string BusinessAreas { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int? Type { get; set; }
        public int? NoAttachment { get; set; }

    }
}
