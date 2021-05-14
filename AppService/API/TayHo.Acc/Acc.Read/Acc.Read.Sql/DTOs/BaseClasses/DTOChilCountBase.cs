using System;
using System.Collections.Generic;
using System.Text;

namespace Acc.Read.Sql.DTOs.BaseClasses
{
    public class DTOChilCountBase
    {
        public int Id { get; set; }
        public bool? IsVisible { get; set; }
        public bool? IsActive { get; set; }
        public int? CreateBy { get; set; }
        public DateTime? CreateDateUTC { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime? UpdateDateUTC { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? ChilCount { get; set; }
    }
    public class DTOAccountInfoBase : DTOChilCountBase
    {
        public string CreateBy_Name { get; set; }
        public byte[] CreateBy_Avartar { get; set; }
        public string CreateBy_Title { get; set; }
        public string CreateBy_Department { get; set; }

        public string ModifyBy_Name { get; set; }
        public byte[] ModifyBy_Avartar { get; set; }
        public string ModifyBy_Title { get; set; }
        public string ModifyBy_Department { get; set; }
    }
}
