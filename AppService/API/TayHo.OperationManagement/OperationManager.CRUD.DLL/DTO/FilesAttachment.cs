using Microsoft.AspNetCore.Http;
using OperationManager.CRUD.DAL.DTO.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OperationManager.CRUD.DAL.DTO
{
    public class FilesAttachment : DOBase
    {
        public int? OwnerById { get; set; }
        public string OwnerByTable { get; set; }
        public string Code { get; set; }
        public string FileName { get; set; }
        public string DisplayName { get; set; }
        public string Tail { get; set; }
        public string Url { get; set; }
        public string Host { get; set; }
        public string Type { get; set; }
        public string Direct { get; set; }
    }
}
