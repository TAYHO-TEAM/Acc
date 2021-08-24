using OperationManager.CRUD.DAL.DTO.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OperationManager.CRUD.DAL.DTO.OperationManagerDTO
{
    public class HandOverDelegate : DOBase
    {
        public string Code { get; set; }
        public string Barcode { get; set; }
        public int? HandOverReceiptId { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public string PhoneContact { get; set; }
        public bool? IsSenderOrReceiver { get; set; }
        public int? Priority { get; set; }
        public int? NoAttachment { get; set; }

    }
}
