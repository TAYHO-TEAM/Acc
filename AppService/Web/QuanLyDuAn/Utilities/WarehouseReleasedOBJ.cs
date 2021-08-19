using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyDuAn.Utilities
{
    public class WarehouseReleasedOBJ
    {
       
        public int? WarehouseStorageId { get; set; }
        public string Code { get; set; }
        public string Barcode { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? TransporterId { get; set; }
        public string Transporter { get; set; }
        public string PhoneContact { get; set; }
        public bool? IsInOrOut { get; set; }
        public int? Priority { get; set; }
        public int? NoAttachment { get; set; }
        public byte? Status { get; set; }
        public string token { get; set; }
        public int? Key { get; set; }
    }
}