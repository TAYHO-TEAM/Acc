using OperationManager.CRUD.DAL.DTO.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OperationManager.CRUD.DAL.DTO
{
    public class Defective : DOBase
    {
        public int? ItemsId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? Type { get; set; }
        public string Description { get; set; }

    }
}
