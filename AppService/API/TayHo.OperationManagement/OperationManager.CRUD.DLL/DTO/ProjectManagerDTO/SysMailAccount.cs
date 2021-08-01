using OperationManager.CRUD.DAL.DTO.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OperationManager.CRUD.DAL.DTO.ProjectManagerDTO
{
    public class SysMailAccount : DOBase
    {
        public int? SysAutoSendMailId { get; set; }
        public string Email { get; set; }
        public int? Type { get; set; }

    }
}
