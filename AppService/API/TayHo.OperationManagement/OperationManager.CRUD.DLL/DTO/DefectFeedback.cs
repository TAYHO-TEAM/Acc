using OperationManager.CRUD.DAL.DTO.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OperationManager.CRUD.DAL.DTO
{
    public class DefectFeedback : DOBase
    {
        public int? RealEstateId { get; set; }
        public int? CustomerId { get; set; }
        public int? DefectiveId { get; set; }
        public string Note { get; set; }
        public int? NoAttachment { get; set; }

    }
}
