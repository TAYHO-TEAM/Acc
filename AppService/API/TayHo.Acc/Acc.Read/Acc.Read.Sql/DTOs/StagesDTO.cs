using Acc.Read.Sql.DTOs.BaseClasses;
using System;

namespace Acc.Read.Sql.DTOs
{
    public class StagesDTO : SysDTOBase
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string Descriptions { get; set; }
    }
}
