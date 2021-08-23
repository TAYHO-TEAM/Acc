using OperationManager.CRUD.DAL.DTO.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OperationManager.CRUD.DAL.DTO.OperationManagerDTO
{
    public class HandOverItem : DOBase
    {
        public string Code { get; set; }
        public string Barcode { get; set; }
        public int? CategoryUnitId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? Priority { get; set; }

    }
}
