using OperationManager.CRUD.DAL.DTO.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OperationManager.CRUD.DAL.DTO.OperationManagerDTO
{
    public class CategoryGoods : DOBase
    {
        public int? ParentId { get; set; }
        public string Code { get; set; }
        public string Barcode { get; set; }
        public string Title { get; set; }
        public int? Hight { get; set; }
        public int? Width { get; set; }
        public int? Depth { get; set; }
        public int? UnitId { get; set; }
        public int? UnitMeasureId { get; set; }
        public int? Weight { get; set; }
        public int? WeightUp { get; set; }
        public int? UnitWeightId { get; set; }
        public string Description { get; set; }
        public int? Type { get; set; }
        public int? Priority { get; set; }

    }
}
