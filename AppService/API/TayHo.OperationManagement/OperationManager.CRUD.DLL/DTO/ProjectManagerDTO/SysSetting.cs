using OperationManager.CRUD.DAL.DTO.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OperationManager.CRUD.DAL.DTO.ProjectManagerDTO
{
    public class SysSetting : DOBase
    {
        public int? ParentId { get; set; }
        public string Code { get; set; }
        public string Barcode { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int? TypeId { get; set; }
        public string SettingContent { get; set; }
        public int? Priority { get; set; }

    }
}
