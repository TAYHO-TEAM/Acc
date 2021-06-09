using OperationManager.CRUD.DAL.DTO.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OperationManager.CRUD.DAL.DTO
{
    public class WarehouseGoodsStorage : DOBase
    {
        public int? WarehouseGoodsId { get; set; }
        public int? WarehouseStorageId { get; set; }
        public string Code { get; set; }
        public string Barcode { get; set; }
        public int? PositionX { get; set; }
        public int? PositionY { get; set; }
        public int? PositionZ { get; set; }
        public int? Hight { get; set; }
        public int? Width { get; set; }
        public int? Depth { get; set; }
        public string Unit { get; set; }
        public int? UnitType { get; set; }
        public int? Weight { get; set; }
        public int? WeightUp { get; set; }
        public string UnitWeight { get; set; }
        public int? UnitWeightType { get; set; }
        public int? PriorityX { get; set; }
        public int? PriorityY { get; set; }

    }
}
