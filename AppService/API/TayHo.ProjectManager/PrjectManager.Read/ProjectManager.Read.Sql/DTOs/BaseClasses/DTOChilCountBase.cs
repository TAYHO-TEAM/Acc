using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Read.Sql.DTOs.BaseClasses
{
    public class DTOChilCountBase : DTOBase
    {
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
    public class DTOAccountInfoPermitBase : DTOAccountInfoBase
    {
        public int PermistionId { get; set; }
    }
}
