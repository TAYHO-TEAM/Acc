using OperationManager.CRUD.DAL.DTO.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OperationManager.CRUD.DAL.DTO.OperationManagerDTO
{
    public class DefectAcceptance : DOBase
    {
        public int? Type { get; set; }
        public int? DefectFixId { get; set; }
        public int? DefectFeedbackId { get; set; }
        public int? DefectFeedbackDetailId { get; set; }
        public int? CustomerInfoId { get; set; }
        public string Note { get; set; }
        public int? NoAttachment { get; set; }
    }
}
