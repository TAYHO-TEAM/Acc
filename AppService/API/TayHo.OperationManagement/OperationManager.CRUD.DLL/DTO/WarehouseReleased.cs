using OperationManager.CRUD.DAL.DTO.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OperationManager.CRUD.DAL.DTO
{
    public class WarehouseReleased : DOBase
    {
        public int? WarehouseStorageId { get; set; }
        public string Code { get; set; }
        public string Barcode { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? TransporterId { get; set; }
        public string Transporter { get; set; }
        public string PhoneContact { get; set; }
        public bool? IsInOrOut { get; set; }
        public int? Priority { get; set; }
        public int? NoAttachment { get; set; }

    }
}
