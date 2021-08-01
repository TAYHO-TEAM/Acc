using OperationManager.CRUD.DAL.DTO.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OperationManager.CRUD.DAL.DTO.OperationManagerDTO
{
    public class DefectFeedbackDetail : DOBase
    {
        public int? DefectFeedbackId { get; set; }
        public int? DefectiveId { get; set; }
        public string Code { get; set; }
        public string Barcode { get; set; }
        public string Note { get; set; }
        public int? NoAttachment { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? FinishDate { get; set; }

    }
}
