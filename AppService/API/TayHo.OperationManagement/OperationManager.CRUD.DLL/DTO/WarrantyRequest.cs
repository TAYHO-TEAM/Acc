using OperationManager.CRUD.DAL.DTO.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OperationManager.CRUD.DAL.DTO
{
    public class WarrantyRequest : DOBase
    {
        public int? CustomerInfoId { get; set; }
        public int? ContructionId { get; set; }
        public string Note { get; set; }
        public byte? NoAttachment { get; set; }

    }
}
