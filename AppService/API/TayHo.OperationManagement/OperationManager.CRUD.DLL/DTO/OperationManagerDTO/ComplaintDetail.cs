using OperationManager.CRUD.DAL.DTO.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OperationManager.CRUD.DAL.DTO.OperationManagerDTO
{
    public class ComplaintDetail : DOBase
    {
        public string Code { get; set; }
        public string Barcode { get; set; }
        public int? ComplaintId { get; set; }
        public int? ComplaintsTypeId { get; set; }
        public int? NoAttachment { get; set; }

    }
}
