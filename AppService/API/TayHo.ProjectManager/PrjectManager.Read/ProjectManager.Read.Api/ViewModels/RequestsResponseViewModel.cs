using ProjectManager.Read.Api.ViewModels.BaseClasses;
using ProjectManager.Read.Sql.DTOs.DTO;
using System;
using System.Collections.Generic;

namespace ProjectManager.Read.Api.ViewModels
{
    public class RequestsResponseViewModel : BaseResponseViewModel
    {
        public int? ProjectId { get; set; }
        public string Code { get; set; }
        public int? RequestFromId { get; set; }
        public int? StageId { get; set; }
        public byte? Priority { get; set; }
        public int? ReplyById { get; set; }
        public DateTime? SendDateTime { get; set; }
        public byte? NoAttachment { get; set; }
        public bool? Insert { get; set; }
        public bool? Update { get; set; }
        public bool? Delate { get; set; }
        public bool? View { get; set; }
        public List<ResponseRegistDTO> ResponseRegistDTOs { get; set; }
    }
}
