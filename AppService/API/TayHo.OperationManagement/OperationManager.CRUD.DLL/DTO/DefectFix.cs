using OperationManager.CRUD.DAL.DTO.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OperationManager.CRUD.DAL.DTO
{
    public class DefectFix : DOBase
    {
        public int? DefectFeedbackId { get; set; }
        public string Fixer { get; set; }
        public string FixerPhone { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? Deadline { get; set; }
        public DateTime? FixedDate { get; set; }
        public string Result { get; set; }
        public int? ResultType { get; set; }
        public string Note { get; set; }
        public int? NoAttachment { get; set; }

    }
}
