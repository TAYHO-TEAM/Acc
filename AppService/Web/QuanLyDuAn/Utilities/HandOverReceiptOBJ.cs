using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyDuAn.Utilities
{
    public class HandOverReceiptOBJ
    {
        public int? Key { get; set; }
        public string Code { get; set; }
        public string Barcode { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public int? WarehouseStorageId { get; set; }
        public string SendAddress { get; set; }
        public int? SendStreetId { get; set; }
        public int? SendDistrictId { get; set; }
        public int? SendWardId { get; set; }
        public int? SendCityId { get; set; }
        public int? SendCountryId { get; set; }
        public string ReceiveAddress { get; set; }
        public int? ReceiveStreetId { get; set; }
        public int? ReceiveDistrictId { get; set; }
        public int? ReceiveWardId { get; set; }
        public int? ReceiveCityId { get; set; }
        public int? ReceiveCountryId { get; set; }
        public bool? IsInOrOut { get; set; }
        public int? Priority { get; set; }
        public int? NoAttachment { get; set; }
        public int? Type { get; set; }
        public byte? Status { get; set; }
        public string token { get; set; }
    }
}