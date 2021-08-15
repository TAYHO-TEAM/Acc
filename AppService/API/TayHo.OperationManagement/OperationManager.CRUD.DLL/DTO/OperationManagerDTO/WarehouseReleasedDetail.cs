using OperationManager.CRUD.DAL.DTO.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OperationManager.CRUD.DAL.DTO.OperationManagerDTO
{
    public class WarehouseReleasedDetail : DOBase
    {
        public int? WarehouseStorageId { get; set; }
        public int? WarehouseReleasedId { get; set; }
        public int? CategoryGoodsId { get; set; }
        public string Code { get; set; }
        public string Barcode { get; set; }
        public decimal? Quantity { get; set; }
        public string Description { get; set; }
        public int? Priority { get; set; }

    }
}
