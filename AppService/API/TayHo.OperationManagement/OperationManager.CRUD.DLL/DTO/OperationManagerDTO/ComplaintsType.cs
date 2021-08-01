using OperationManager.CRUD.DAL.DTO.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OperationManager.CRUD.DAL.DTO.OperationManagerDTO
{
    public class ComplaintsType : DOBase
    {
        public string Code { get; set; }
        public string Barcode { get; set; }
        public string Title { get; set; }
        public int? Type { get; set; }
        public string Description { get; set; }
        public string ResolveSuggest { get; set; }

    }
}
