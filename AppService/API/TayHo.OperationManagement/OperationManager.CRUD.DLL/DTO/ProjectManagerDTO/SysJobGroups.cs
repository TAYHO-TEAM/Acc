using OperationManager.CRUD.DAL.DTO.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OperationManager.CRUD.DAL.DTO.ProjectManagerDTO
{
    public class SysJobGroups : DOBase
    {
        public string Code { get; set; }
        public string Barcode { get; set; }
        public int? GroupsId { get; set; }
        public int? SysJobId { get; set; }

    }
}
