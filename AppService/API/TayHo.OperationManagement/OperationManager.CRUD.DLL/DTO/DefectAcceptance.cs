using OperationManager.CRUD.DAL.DTO.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OperationManager.CRUD.DAL.DTO
{
    public class DefectAcceptance : DOBase
    {
        public int? DefectFixId { get; set; }
        public int? CustomerInfoId { get; set; }
        public string Note { get; set; }
        public int? NoAttachment { get; set; }

    }
}
