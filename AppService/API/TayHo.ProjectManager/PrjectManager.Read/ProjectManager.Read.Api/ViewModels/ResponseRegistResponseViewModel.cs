using ProjectManager.Read.Api.ViewModels.BaseClasses;
using ProjectManager.Read.Sql.DTOs.DTO;
using System;
using System.Collections.Generic;

namespace ProjectManager.Read.Api.ViewModels
{
    public class ResponseRegistResponseViewModel : BaseResponseChilCountViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int? StepProcessId { get; set; }
        public int? RequestRegistId { get; set; }
        public int? GroupId { get; set; }
        public int? ReplyId { get; set; }
        public byte? NoAttachment { get; set; }
        public bool? IsApprove { get; set; }
        public byte? TypeOfResult { get; set; }
        public string AccountName { get; set; }
        public bool? Insert { get; set; }
        public bool? Update { get; set; }
        public bool? Delate { get; set; }
        public bool? View { get; set; }
        
    }
    public class ResponseRegistResponseDetailViewModel : ResponseRegistResponseViewModel
    {
      
        public List<ResponseRegistDTO> ResponseRegistDTOs { get; set; }

    }
}
