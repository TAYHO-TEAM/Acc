using OperationManager.CRUD.DAL.DTO.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OperationManager.CRUD.DAL.DTO.OperationManagerDTO
{
    public class Conversation : DOBase
    {
        public string OwnerTable { get; set; }
        public int? TopicId { get; set; }
        public int? ParentId { get; set; }
        public string Content { get; set; }
        public byte? NoAttachment { get; set; }

    }
}
