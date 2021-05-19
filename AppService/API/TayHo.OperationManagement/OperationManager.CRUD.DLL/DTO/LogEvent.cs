using OperationManager.CRUD.DAL.DTO.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OperationManager.CRUD.DAL.DTO
{
    public class LogEvent : DOBase
    {
        public int? UserId { get; set; }
        public string Event { get; set; }
        public string Action { get; set; }
        public int? OwnerById { get; set; }
        public string OwnerByTable { get; set; }
        public int? FunctionId { get; set; }
        public string Message { get; set; }

    }
}
