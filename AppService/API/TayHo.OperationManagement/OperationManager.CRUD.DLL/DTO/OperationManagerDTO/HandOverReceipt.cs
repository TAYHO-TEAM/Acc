using OperationManager.CRUD.DAL.DTO.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OperationManager.CRUD.DAL.DTO.OperationManagerDTO
{
    public class HandOverReceipt : DOBase
    {
        public string Code { get; set; }
        public string Barcode { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public int? WarehouseStorageId { get; set; }
        public string SendAddress { get; set; }
        public string SendStreet { get; set; }
        public string SendDistrict { get; set; }
        public string SendWard { get; set; }
        public string SendCity { get; set; }
        public string SendCountry { get; set; }
        public string ReceiveAddress { get; set; }
        public string ReceiveStreet { get; set; }
        public string ReceiveDistrict { get; set; }
        public string ReceiveWard { get; set; }
        public string ReceiveCity { get; set; }
        public string ReceiveCountry { get; set; }
        public bool? IsInOrOut { get; set; }
        public int? Priority { get; set; }
        public int? NoAttachment { get; set; }
        public int? Type { get; set; }

    }
}
