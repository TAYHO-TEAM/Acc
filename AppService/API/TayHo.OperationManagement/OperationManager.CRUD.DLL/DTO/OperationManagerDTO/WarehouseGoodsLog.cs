using OperationManager.CRUD.DAL.DTO.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OperationManager.CRUD.DAL.DTO.OperationManagerDTO
{
    public class WarehouseGoodsLog : DOBase
    {
        public int? WarehouseStorageId { get; set; }
        public int? CategoryGoodsId { get; set; }
        public int? Quantity { get; set; }
        public string Code { get; set; }
        public string Barcode { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public int? CheckInBy { get; set; }
        public string Sender { get; set; }
        public int? CheckOutBy { get; set; }
        public string Receiver { get; set; }
        public string PhoneContact { get; set; }
        public bool? IsInOrOut { get; set; }
        public int? Priority { get; set; }

    }
}
