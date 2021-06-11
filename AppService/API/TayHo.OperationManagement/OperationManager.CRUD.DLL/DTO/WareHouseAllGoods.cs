using OperationManager.CRUD.DAL.DTO.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OperationManager.CRUD.DAL.DTO
{
    public class WareHouseAllGoods :DOBase
    {
        public int? ConstructionItemsId { get; set; }
        public int? RealEstateID { get; set; }
        public int? WarehouseStorageId { get; set; }
        public int? ParentId { get; set; }
        public int? CategoryGoodsId { get; set; }
        public int? Quantity { get; set; }
        public int? UnitId { get; set; }

    }
}
