using OperationManager.CRUD.DAL.DTO.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OperationManager.CRUD.DAL.DTO.OperationManagerDTO
{
    public class WarehouseStorage : DOBase
    {
        public int? RealEstateId { get; set; }
        public int? ParentId { get; set; }
        public string Code { get; set; }
        public string Barcode { get; set; }
        public int? CategoryStorageId { get; set; }
        public string Title { get; set; }
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
        public int? Priority { get; set; }

    }
}
